using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SHH.UI.Curve.Core;
using SHH.UI.Curve.Pub;

namespace SHH.UI.Curve.Thumbnail
{
    /// <summary>
    /// 柱状图缩略图
    /// </summary>
    [TemplatePart(Name = "dragBorder", Type = typeof(DragContentControl))]
    [TemplatePart(Name = "drawingCanvas", Type = typeof(DrawingCanvas))]
    [TemplatePart(Name = "tbk_LeftTime", Type = typeof(TextBlock))]
    [TemplatePart(Name = "tbk_RightTime", Type = typeof(TextBlock))]
    public class SHHCurveThumbnail : SHHContentControl
    {
        //画板
        private DrawingCanvas canvas;
        //线条集合
        private List<BrokenLine> brokenLines = new List<BrokenLine>();
        //滑块
        private DragContentControl dragBorder;
        //时间间隔
        private TimeInterval timeInterval = new TimeInterval();
        //右边显示的时间
        private TextBlock tbk_RightTime;
        //当前区间位置
        private Position position;

        //数据改变事件,SHHCurveDetail控件通过此事件触发数据更新
        public event Action<List<BrokenLine>, TimeInterval> OnDataChanged;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SHHCurveThumbnail()
        {
            LoadStyleFromAssembly("SHHRectangleThumbnail;component/Style/SHHCurveThumbnailStyle.xaml", UriKind.Relative, "SHHCurveThumbnailStyle");
            DataContext = this;
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //绘制曲线
            DrawingLinesOnCanvas();
            if (dragBorder == null || canvas == null)
            {
                throw new Exception("Load Template Failed");
            }
            //数据改变
            DataChanged(new Position() { p1 = 0, p2 = dragBorder.ActualWidth / canvas.ActualWidth });
        }

        #region 绘制代码
        /// <summary>
        /// 在画板上绘制折线
        /// </summary>
        public void DrawingLinesOnCanvas()
        {
            canvas.ClearVisual();

            for (int i = 0; i < BrokenLines.Count; ++i)
            {
                //每条线作为一个visual对象
                DrawingVisual visual = new DrawingVisual();
                DrawingLinesOnVisual(visual, BrokenLines[i], i);
                canvas.AddVisual(visual);
            }
        }

        /// <summary>
        /// 在Visual中绘制折线
        /// </summary>
        /// <param name="visual"></param>
        /// <param name="brush"></param>
        /// <param name="thickness"></param>
        /// <param name="index">几组数据</param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void DrawingLinesOnVisual(DrawingVisual visual, BrokenLine brokenLine, Int32 index)
        {
            using (DrawingContext dc = visual.RenderOpen())
            {
                int count = brokenLine.Points.Count;
                //每n个绘制一次
                int n = count / 200 + 1;

                for (int i = n; i < brokenLine.Points.Count; i += n)
                {
                    DrawingRectangle(dc,
                        brokenLine.Brush,
                        brokenLine.Thickness,
                        //brokenLine.Points[i - n],
                        brokenLine.Points[i],
                        i / (brokenLine.Points.Count + 0.0),
                        index  //组数
                        );
                }

                #region
                //缩略图不需要绘制线帽
                //if (brokenLine.BrokenLineCapType != BrokenLineCapType.None)
                //{
                //    //线帽比线条的个数多一个
                //    for (int i = 0; i < brokenLine.Points.Count; i += n)
                //    {
                //        DrawLineCap(dc,
                //            brokenLine.Brush,
                //            brokenLine.Points[i], brokenLine.BrokenLineCapType);
                //    }
                //}
            }
        }

        ///// <summary>
        ///// 绘制线帽
        ///// </summary>
        //private void DrawLineCap(DrawingContext dc, Brush brush, Point p, BrokenLineCapType type)
        //{
        //    switch (type)
        //    {
        //        case BrokenLineCapType.None:
        //            break;

        //        case BrokenLineCapType.Circle:
        //            dc.DrawEllipse(brush, new Pen(brush, 1), p, 2, 2);
        //            break;

        //        case BrokenLineCapType.Rectangle:
        //            break;

        //        case BrokenLineCapType.Square:
        //            break;

        //        case BrokenLineCapType.Triangle:
        //            break;
        //    }
        //}
        #endregion

        /// <summary>
        /// 绘制线条
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="brush"></param>
        /// <param name="thickness"></param>
        /// <param name="p1">Y轴当前位置的百分比</param>
        /// <param name="flag">X轴当前位置点的百分比</param>
        /// <param name="p2">组数</param>
        private void DrawingRectangle(DrawingContext dc, Brush brush, double thickness, Point p1, double flag, int index)
        {
            //Point结构里存的是位置的比例,这里要做一下转换
            //Canvas的坐标原点在左上角
            //Point point1 = new Point(p1.X * canvas.ActualWidth, canvas.ActualHeight - p1.Y * canvas.ActualHeight);
            //Point point2 = new Point(p2.X * canvas.ActualWidth, canvas.ActualHeight - p2.Y * canvas.ActualHeight);

            //dc.DrawLine(new Pen(brush, thickness), point1, point2);


            Point point1 = new Point(flag * canvas.ActualWidth + index * (2 * thickness), canvas.ActualHeight - p1.Y * canvas.ActualHeight);

            //dc.DrawRectangle(brush, null, new Rect(point1.X, point1.Y, thickness, canvas.ActualHeight - point1.Y));
            dc.DrawRectangle(brush, null, new Rect(point1.X, point1.Y, thickness, p1.Y * canvas.ActualHeight));

        }
        #endregion

        /// <summary>
        /// 滑块左移
        /// </summary>
        public void MoveLeft()
        {
            dragBorder.MoveLeft();
        }


        /// <summary>
        /// 应用模版文件时触发
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //获取模版里的对象
            canvas = GetTemplateChild<DrawingCanvas>("drawingCanvas");
            tbk_RightTime = GetTemplateChild<TextBlock>("tbk_RightTime");
            dragBorder = GetTemplateChild<DragContentControl>("dragBorder");

            dragBorder.OnDragBorderMove += DataChanged;
        }

        /// <summary>
        /// 数据发生变化时调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataChanged(Position p)
        {
            if (OnDataChanged != null)
            {
                //更新选中区间
                position = p;

                //筛选出的线条区间
                List<BrokenLine> lines = new List<BrokenLine>();

                //遍历线条
                for (int i = 0; i < brokenLines.Count; ++i)
                {

                    //筛选出集合的值
                    List<Point> points = new List<Point>();
                    //选择点区间
                    for (int j = (int)(brokenLines[i].Points.Count * p.p1); j <= (int)(brokenLines[i].Points.Count * p.p2) && j < (int)(brokenLines[i].Points.Count); ++j)
                    {
                        points.Add(brokenLines[i].Points[j]);
                    }
                    lines.Add(new BrokenLine(points, brokenLines[i].Brush, brokenLines[i].Thickness, BrokenLineCapType.None, brokenLines[i].Name));





                    //////筛选出集合的值
                    //List<Double> points = new List<Double>();

                    //for (int j = 0; j < brokenLines[i].Points.Count; ++j)
                    //{
                    //    if (brokenLines[i].Points[j].X > p.p1 && brokenLines[i].Points[j].X < p.p2)
                    //    {
                    //        points.Add(brokenLines[i].Points[j]);
                    //    }
                    //}

                    ////计算集合内的值的X占筛选框的百分比
                    //for (int j = 0; j < points.Count(); ++j)
                    //{
                    //    points[j] = new Point((points[j].X - p.p1) / (p.p2 - p.p1), points[j].Y);
                    //}


                    //lines.Add(new BrokenLine(points, brokenLines[i].Brush, brokenLines[i].Thickness, brokenLines[i].BrokenLineCapType, brokenLines[i].Name));



                    #region 之前的逻辑
                    //List<Double> points = new List<Double>();

                    //选择点区间
                    //for (int j = (int)(brokenLines[i].Points.Count * p.p1);
                    //    j < (int)(brokenLines[i].Points.Count * p.p2); ++j)
                    //{
                    //    points.Add(brokenLines[i].Points[j]);
                    //}
                    //lines.Add(new BrokenLine(points, brokenLines[i].Brush, brokenLines[i].Thickness, brokenLines[i].BrokenLineCapType, brokenLines[i].Name));
                    #endregion
                }

                //计算时间区间
                TimeSpan timeSpan = EndTime - StartTime;

                TimeInterval t = new TimeInterval(StartTime + new TimeSpan((long)(timeSpan.Ticks * p.p1)),
                    StartTime + new TimeSpan((long)(timeSpan.Ticks * p.p2)));
                SelectedStartTime = t.StartTime;
                SelectedEndTime = t.EndTime;

                //如果区间大于,修改右边时间的显示位置,以免覆盖
                if (p.p2 > 0.85)
                {
                    //改变滑块右边的时间位置
                    dragBorder.ChangeRightTimePosition(0);
                    //改变缩略图右边的时间位置
                    //tbk_RightTime.SetValue(Canvas.RightProperty, -57.0);
                    tbk_RightTime.Visibility = Visibility.Collapsed;
                }
                else
                {
                    dragBorder.ChangeRightTimePosition(1);
                    //tbk_RightTime.SetValue(Canvas.RightProperty, -19.0);
                    tbk_RightTime.Visibility = Visibility.Visible;
                }

                //触发事件
                OnDataChanged?.Invoke(lines, t);
            }
        }

        /// <summary>
        /// 绘制区域高度
        /// </summary>
        public double CanvasHeight { get => canvas.ActualHeight; }

        /// <summary>
        /// 绘制区域宽度
        /// </summary>
        public double CanvasWidth { get => canvas.ActualWidth; }

        /// <summary>
        /// 线条集合
        /// </summary>
        public List<BrokenLine> BrokenLines { get => brokenLines; set => brokenLines = value; }

        /// <summary>
        /// 选中区间的开始时间
        /// </summary>
        public DateTime SelectedStartTime { get => dragBorder.StartTime; set => dragBorder.StartTime = value; }

        /// <summary>
        /// 选中区间的结束时间
        /// </summary>
        public DateTime SelectedEndTime { get => dragBorder.EndTime; set => dragBorder.EndTime = value; }

        /// <summary>
        /// 选中的时间区间
        /// </summary>
        public TimeInterval SelectedTimeInterval { get => dragBorder.TimeInterval; set => dragBorder.TimeInterval = value; }


        /// <summary>
        /// 总时间区间
        /// </summary>
        public TimeInterval TimeInterval
        {
            get => timeInterval;
            set
            {
                timeInterval = value;
                SetValue(StartTimeProperty, value.StartTime);
                SetValue(EndTimeProperty, value.EndTime);
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get => TimeInterval.StartTime;
            set
            {
                TimeInterval.StartTime = value;
                SetValue(StartTimeProperty, value);
            }
        }
        public static DependencyProperty StartTimeProperty = DependencyProperty.Register(
            "StartTime",
            typeof(DateTime),
            typeof(SHHCurveThumbnail),
            new PropertyMetadata(DateTime.Now));

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get => timeInterval.EndTime;
            set
            {
                TimeInterval.EndTime = value;
                SetValue(EndTimeProperty, value);
            }
        }
        public static DependencyProperty EndTimeProperty = DependencyProperty.Register(
            "EndTime",
            typeof(DateTime),
            typeof(SHHCurveThumbnail),
            new PropertyMetadata(DateTime.Now));

        /// <summary>
        /// 当前区间位置
        /// </summary>
        public Position Position { get => position; set => position = value; }
    }
}
