using System;
using System.Collections.Generic;
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
using Yuzu.ProductMonitor.Models;

namespace Yuzu.ProductMonitor.UserControls
{
    /// <summary>
    /// RaderUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class RaderUserControl : UserControl
    {
        public RaderUserControl()
        {
            InitializeComponent();

            // 窗体大小发生改变时候，图形大小也会改变，绑定事件处理器
            SizeChanged += (sender, e) => Draw(); // 可使用 Alt+Enter 生成事件处理方法
        }

        /// <summary>
        /// 数据源：支持数据绑定 依赖属性
        /// </summary>
        public List<RaderModel> ItemSource
        {
            get { return (List<RaderModel>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // 依赖属性注册
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(List<RaderModel>), typeof(RaderUserControl));

        ///<summary>
        ///画图方法
        /// </summary>
        public void Draw()
        {
            // 判断是否有数据
            if (ItemSource == null || ItemSource.Count == 0) return;

            // 清除之前画的
            masterCanvas.Children.Clear();
            polygon1.Points.Clear();
            polygon2.Points.Clear();
            polygon3.Points.Clear();
            polygon4.Points.Clear();
            polygon5.Points.Clear();

            // 调整大小(正方形)：以外部控件的长宽最小值确定雷达图的直径
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            layGrid.Height = size;
            layGrid.Width = size;
            // 半径
            double radius = size / 2;

            // 步长
            double step = 360.0 / ItemSource.Count;

            for (int i = 0; i < ItemSource.Count; i++)
            {
                double x = (radius - 20) * Math.Cos((step * i - 90) * Math.PI / 180);//x偏移量
                double y = (radius - 20) * Math.Sin((step * i - 90) * Math.PI / 180);//y偏移量

                // X Y坐标
                polygon1.Points.Add(new Point(radius + x, radius + y));
                polygon2.Points.Add(new Point(radius + x * 0.75, radius + y * 0.75));
                polygon3.Points.Add(new Point(radius + x * 0.5, radius + y * 0.5));
                polygon4.Points.Add(new Point(radius + x * 0.25, radius + y * 0.25));
                // 数据多边形
                polygon5.Points.Add(new Point(
                    radius + x * ItemSource[i].ItemValue * 0.01, 
                    radius + y * ItemSource[i].ItemValue * 0.01));

                // 文字处理
                TextBlock txt = new TextBlock();
                txt.Width = 60;
                txt.FontSize = 10;
                txt.TextAlignment = TextAlignment.Center;
                txt.Text = ItemSource[i].ItemName;
                txt.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                txt.SetValue(Canvas.LeftProperty, 
                    radius + (radius - 10) * Math.Cos((step * i - 90) * Math.PI / 180) - 30); //设置左边间距
                txt.SetValue(Canvas.TopProperty, 
                    radius + (radius - 10) * Math.Sin((step * i - 90) * Math.PI / 180) - 7);   //设置上边间距

                masterCanvas.Children.Add(txt);
            }
        }
    }
}
