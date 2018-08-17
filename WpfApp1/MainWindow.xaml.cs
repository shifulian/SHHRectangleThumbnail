using Microsoft.Win32;
using SHH.UI.Curve.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 载入控件时调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            #region 柱状图逻辑
            //每种柱状点的个数
            int pNum = 500;
            List<Double> list1 = new List<Double>();
            for (int i = 0; i < pNum; ++i)
            {
                list1.Add(new Random(Guid.NewGuid().GetHashCode()).Next(0, 100) / 100.0);
            }
            BrokenLine line1 = new BrokenLine(list1, new SolidColorBrush(Color.FromRgb(79, 188, 195)), 3, BrokenLineCapType.Circle, "柱状1");
            thumbnail.BrokenLines.Add(line1);

            List<Double> list2 = new List<Double>();
            for (int i = 0; i < pNum; ++i)
            {
                list2.Add(new Random(Guid.NewGuid().GetHashCode()).Next(0, 100) / 100.0);
            }
            BrokenLine line2 = new BrokenLine(list2, new SolidColorBrush(Colors.Red), 3, BrokenLineCapType.Circle, "柱状2");
            thumbnail.BrokenLines.Add(line2);

            List<Double> list3 = new List<Double>();
            for (int i = 0; i < pNum; ++i)
            {
                list3.Add(new Random(Guid.NewGuid().GetHashCode()).Next(0, 100) / 100.0);
            }
            BrokenLine line3 = new BrokenLine(list3, new SolidColorBrush(Colors.Green), 3, BrokenLineCapType.Circle, "柱状3");
            thumbnail.BrokenLines.Add(line3);

            List<Double> list4 = new List<Double>();
            for (int i = 0; i < pNum; ++i)
            {
                list4.Add(new Random(Guid.NewGuid().GetHashCode()).Next(0, 100) / 100.0);
            }
            BrokenLine line4 = new BrokenLine(list4, new SolidColorBrush(Colors.Black), 3, BrokenLineCapType.Circle, "柱状4");
            thumbnail.BrokenLines.Add(line4);

            List<Double> list5 = new List<Double>();
            for (int i = 0; i < pNum; ++i)
            {
                list5.Add(new Random(Guid.NewGuid().GetHashCode()).Next(0, 100) / 100.0);
            }
            BrokenLine line5 = new BrokenLine(list5, new SolidColorBrush(Color.FromRgb(153, 0, 255)), 3, BrokenLineCapType.Circle, "柱状5");
            thumbnail.BrokenLines.Add(line5);

            List<Double> list6 = new List<Double>();
            for (int i = 0; i < pNum; ++i)
            {                      //Guid.NewGUID() 生成一个新的 GUID 唯一值    random.next(int32,int32)在这个范围内产生的随机数
                list6.Add(new Random(Guid.NewGuid().GetHashCode()).Next(0, 100) / 100.0);
            }
            BrokenLine line6 = new BrokenLine(list6, new SolidColorBrush(Color.FromRgb(241, 194, 50)), 3, BrokenLineCapType.Circle, "柱状6");
            thumbnail.BrokenLines.Add(line6);

            #endregion

            #region
            //        //每条曲线点的个数
            //        int pNum = 500;

            //        //曲线1
            //        List<Point> points1 = new List<Point>();
            //        for (int i = 0; i < pNum; ++i)
            //        {
            //            //正弦曲线
            //            points1.Add(new Point(1.0 / (pNum - 1) * i,
            //(thumbnail.CanvasHeight / 2 + Math.Sin(i / 180.0 * Math.PI) * 15) / thumbnail.CanvasHeight));
            //        }
            //        BrokenLine line1 = new BrokenLine(points1, new SolidColorBrush(Color.FromRgb(79, 188, 195)), 1, BrokenLineCapType.Diamond, "曲线1");
            //        thumbnail.BrokenLines.Add(line1);

            //        //曲线2
            //        List<Point> points2 = new List<Point>();
            //        for (int i = 0; i < pNum; ++i)
            //        {
            //            //余弦曲线
            //            points2.Add(new Point(1.0 / (pNum - 1) * i,
            //(thumbnail.CanvasHeight / 2 + Math.Cos(i / 180.0 * Math.PI) * 15) / thumbnail.CanvasHeight));
            //        }
            //        BrokenLine line2 = new BrokenLine(points2, new SolidColorBrush(Color.FromRgb(141, 222, 166)), 1, BrokenLineCapType.Square, "曲线2");
            //        thumbnail.BrokenLines.Add(line2);

            //        //曲线3
            //        List<Point> points3 = new List<Point>();
            //        for (int i = 0; i < pNum; ++i)
            //        {
            //            points3.Add(new Point(1.0 / (pNum - 1) * i,
            //(thumbnail.CanvasHeight / 2 + Math.Sin(i / 180.0 * Math.PI) * 15 / 2) / thumbnail.CanvasHeight));
            //        }
            //        BrokenLine line3 = new BrokenLine(points3, new SolidColorBrush(Color.FromRgb(186, 233, 93)), 1, BrokenLineCapType.RectangleH, "曲线3");
            //        thumbnail.BrokenLines.Add(line3);

            //        //曲线4
            //        List<Point> points4 = new List<Point>();
            //        for (int i = 0; i < pNum; ++i)
            //        {
            //            points4.Add(new Point(1.0 / (pNum - 1) * i,
            //(thumbnail.CanvasHeight / 2 + Math.Cos(i / 180.0 * Math.PI) * 15 / 2) / thumbnail.CanvasHeight));
            //        }
            //        BrokenLine line4 = new BrokenLine(points4, new SolidColorBrush(Color.FromRgb(97, 198, 58)), 1, BrokenLineCapType.Triangle, "曲线4");
            //        thumbnail.BrokenLines.Add(line4);

            //        //曲线5
            //        List<Point> points5 = new List<Point>();
            //        for (int i = 0; i < pNum; ++i)
            //        {
            //            points5.Add(new Point(1.0 / (pNum - 1) * i,
            //(thumbnail.CanvasHeight / 2 + Math.Sin(i / 180.0 * Math.PI) * 15 / 4) / thumbnail.CanvasHeight));
            //        }
            //        BrokenLine line5 = new BrokenLine(points5, new SolidColorBrush(Color.FromRgb(190, 185, 226)), 1, BrokenLineCapType.RectangleV, "曲线5");
            //        thumbnail.BrokenLines.Add(line5);

            //        //曲线6
            //        List<Point> points6 = new List<Point>();
            //        for (int i = 0; i < pNum; ++i)
            //        {
            //            points6.Add(new Point(1.0 / (pNum - 1) * i,
            //(thumbnail.CanvasHeight / 2 + Math.Cos(i / 180.0 * Math.PI) * 15 / 4) / thumbnail.CanvasHeight));
            //        }
            //        BrokenLine line6 = new BrokenLine(points6, new SolidColorBrush(Color.FromRgb(130, 181, 247)), 1, BrokenLineCapType.TriangleR, "曲线6");
            //        thumbnail.BrokenLines.Add(line6);
            #endregion

            //开始时间
            thumbnail.StartTime = new DateTime(2017, 1, 1);

            //结束时间
            thumbnail.EndTime = new DateTime(2018, 1, 1);

            //初始化
            thumbnail.Init();
        }

        /// <summary>
        /// 缩略图改变时触发
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="timeInterval"></param>
        private void Thumbnail_OnDataChanged(List<BrokenLine> lines, TimeInterval timeInterval)
        {
            //添加中间层来获取最大最小值

            //重绘事件
            detail.RePaint(lines, timeInterval, 0, 0.3);
        }

        /// <summary>
        /// 点击按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            switch (s)
            {
                case "放大":
                    detail.ZoomIn();
                    break;
                case "缩小":
                    detail.ZoomOut();
                    break;
                case "X轴放大":
                    detail.ZoomInAxisX();
                    break;
                case "X轴缩小":
                    detail.ZoomOutAxisX();
                    break;
                case "Y轴放大":
                    detail.ZoomInAxisY();
                    break;
                case "Y轴缩小":
                    detail.ZoomOutAxisY();
                    break;
                case "++X轴标签":
                    detail.AddAxisXLabel();
                    break;
                case "--X轴标签":
                    detail.RemoveAxisXLabel();
                    break;
                case "++Y轴标签":
                    detail.AddAxisYLabel();
                    break;
                case "--Y轴标签":
                    detail.RemoveAxisYLabel();
                    break;
                case "密度增加":
                    detail.PointDensityUp();
                    break;
                case "密度减少":
                    detail.PointDensityDown();
                    break;
                case "启用圆点":
                    detail.ChangeCapShow();
                    break;
                case "显示标尺":
                    detail.ChangeRulerShow();
                    break;
                case "显示提示":
                    detail.ChangeToolTipShow();
                    break;
                case "原始尺寸":
                    detail.OriginalSize();
                    break;              

                #region 外部实现
                case "全屏显示":
                    ShowFullScreen();
                    break;
                case "下载":
                    Download();
                    break;
                    #endregion
            }
        }

      

        /// <summary>
        /// 下载图片
        /// </summary>
        private void Download()
        {
            RenderTargetBitmap bmp = detail.DownloadPicture(detail, (int)detail.ActualWidth, (int)detail.ActualHeight);

            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "保存到图片",
                Filter = "图像文件(*.png)|*.png|所有文件(*.*)|*.*"
            };
            bool? b = dialog.ShowDialog();
            if (b == null || b == false)
            {
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(dialog.FileName, FileMode.Create))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bmp));
                    encoder.Save(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 全屏
        /// </summary>
        private void ShowFullScreen()
        {
            //this.Cursor = Cursors.Wait;
            this.WindowState = WindowState.Maximized;
            detail.RePaint();
        }
    }
}