   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxToggleButton  �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels F�Name �� Triggers  ComboBoxTemplate �Name	 � ColumnDefinitions
 �Name � AllowsTransparency �� Mode �� RelativeSource �� MaxDropDownHeight �� ElementName ��Name �� ClearTypeHint ��Name ��Name ��Name-   'System.Windows.Input.KeyboardNavigation    DirectionalNavigation d�Name d� 	IsChecked ��Name �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat �� ContentStringFormat J� IsHitTestVisible P� 
SourceName P� Property  P� Value! �� 
TargetName" ]� 
Conditions# �� Property$ �� Value  TextBox.Static.Background% �� Color  ComboBoxEditableTextBox  ComboBoxEditableTemplate& ��Name' �� 
IsReadOnly # CurveConfigurationComboBoxStyle( �� Triggers�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %a  &	        &	 �    7   &	 �
    &	 �
    &	     7   7  7  &	 �    7  7  �� 5      "  d�6)   .�5   
   ��  �@�OverridesDefaultStyle . 62   �� 5   
    � �� .  6&   �� 5   
    � |� .  6&   �� 5   
    �@��	ClickMode$ Press=�6&   �� 5	   
    � �� 5
      �� 5      " d�6"   .R�5      �� $ templateRoot��6    . #��z��6N   #��z��6x   #��z��6�   ._�5      �� $ splitBorder��6!   #��� r�66   $��0q�6�   $��Right=�6�   $��0q�6�   #��z��6�   ._�5      F� $ arrow��6#   $��Center=�62   $��Center=�6M   
���   �O����        �        �g5  	= �g5  	= ��g5  	= ��j ��j ���j     	6w   5      5       5      5      5      5      �� 5      " ��6/   .R�5   
   � $ templateRoot��6    . 	 5      �� 5      $��* �6#   �� 5      #��� r�6#   $��0 �6v   .+�5      � $
 
PART_Popup��6    . $��2��6B   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6V   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5      �� $ shadow��6   #��z 6)   ��6Y   �� *ActualWidth+$ templateRoot��._�5      �� $ dropDownBorder��6   #��� ��65   $��1q�6�   #��� ��6�   ._�5       �� $ DropDownScrollViewer��6'   .��5!      � $
 grid��6#   $ Enabled=�61   .+�5"   "   �� $ canvas��6)   $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5#   &   �� $ 
opaqueRect��60   ��6D   �� *
Background+$ dropDownBorder����6|   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5$   #   �� 5%   "   $ ItemsPresenter��61   $ 	Contained=�6I   # z 6~   5&      5'      5(      5)      5*      d� 5+      $ toggleButton��6   #��z��61   #��z��6]   #��z��6�   $��2��6�   8��   6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+62  �� 5,      $ contentPresenter��6   #��z 69   #��z��6v   #��z 6�   # z 6�   #��z��6)   .  #��z��6�  # z 6�  #��z��6�  5-       5.   
   P� 5/      $ 
PART_Popup��6/    �@�HasDropShadow  . . �50      �� $! shadow��6+    � ��$ 0,0,5,5q�6?   52      P� 53       �@��HasItems  .  . �54      �� $! dropDownBorder��6+    � ��$ 95��6G   55      ]� 56      " 57      �� 58      # �@��
IsGrouping$ . 66   �� 59      "# �@%�IsVirtualizingWhenGrouping$ .  6X   ./�5;      ��  � �� .  6B   5<      P� 5=      $ DropDownScrollViewer��6?    � ��  .  . �5>      �� $! 
opaqueRect��6/    6G   �� *VerticalOffset+$ DropDownScrollViewer�� �@��Top�� 5?      $! 
opaqueRect��60    6H   �� *HorizontalOffset+$ DropDownScrollViewer�� �@��Left5@      5B      �� 5C      $% 	#FFFFFFFF��68   �� 5D      "  ��6,   .�5E   
   ��  �@�OverridesDefaultStyle . 62   �� 5F   
    �@J�	AllowDrop . 6&   �� 5G   
    � ��$ 0��6%   �� 5H   
    � ��$ 0��6&   �� 5I   
    �@�FocusVisualStyle 6-   Z� �� 5J   
    �@��PanningMode$ VerticalFirst=�65   �� 5K   
    �@��IsFlicksEnabled .  63   �� 5L   
    � �� 5M      �� 5N      " ��6"   .R�5O      �� $ PART_ContentHost��6#   
������ |�.  $��Hidden=�6h   $��Hidden=�6�   5P      5R      5S      �� 5T      " ��67   .R�5U   
   � $ templateRoot��6    . 	 5V      �� 5W      $��* �6#   �� 5X      #��� r�6#   $��0 �6v   .+�5Z      � $
 
PART_Popup��6    . $��2��6B   #��� .�6�   $��Bottom=�6  ��6V   �� *IsDropDownOpen+ �� *TemplatedParent+.��5[      �� $ shadow��6   #��z 6*   ��6Z   �� *ActualWidth+$ templateRoot��._�5\      �� $ dropDownBorder��6   #��� ��65   $��1q�6�   #��� ��6�   ._�5]      �� $ DropDownScrollViewer��6'   .��5^      � $
 grid��6#   $ Enabled=�61   .+�5_   "   �� $ canvas��6)   $
��Left=�69   $��0��6T   $	��Top=�6_   $��0��6w   .+�5`   &   �� $ 
opaqueRect��60   ��6D   �� *
Background+$ dropDownBorder����6|   �� *ActualHeight+$ dropDownBorder����6�   �� *ActualWidth+$ dropDownBorder��5a   #   �� 5b   "   $ ItemsPresenter��61   $ 	Contained=�6I   # z 6~   5c      5d      5e      5f      5g      d� 5h      $ toggleButton��6   #��z��61   #��z��6]   #��z��6�   $��2��6�   8��   6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+62  �� 5i      $ border��6   8�� #��z��6]   ._�5j      �� $& PART_EditableTextBox��6   #��z��68   #��z��6�   8�� #��z��6)  ' 6�   �� *
IsReadOnly+ �� *TemplatedParent+6)  5k      5l       5m   
   5o      �� 5r      "  ��64   .�5s   
   ��  � �� �	#FFD4D4D46(   �� 5t   
    � �� �	#FF6666666'   �� 5u   
    � ��$ 1q�6,   �� 5v   
    � ��$
 Auto=�6G   �� 5w   
    � ��$
 Auto=�6E   �� 5x   
    � ��$ 10,0,0,0q�6$   �� 5y   
    � �� . 6:   �� 5z   
    �@��PanningMode$
 Both=�65   �� 5{   
    �@��IsFlicksEnabled .  63   �� 5|   
    � ��$ Center=�65   �� 5}   
    � ��8   6%   ( 5~   
   P� 5       �@��
IsEditable  . . �5�      ��  � �� .  6.   �� 5�       � ��$ 0q�6,   �� 5�       � ��8  6-   5�      5�      5�      