using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Yuzu.ProductMonitor.UserControls;
using Yuzu.ProductMonitor.ViewModels;
using Yuzu.ProductMonitor.Commands;


namespace Yuzu.ProductMonitor.Views
{
    public partial class MainWindow : Window
    {
        // 视图
        private MainWindowVM mainWindow = new MainWindowVM();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mainWindow;
        }

        // 显示车间详情页
        private void ShowWorkShopDetailUC()
        {
            WorkShopDetailUserControl workShopDetailUC = new WorkShopDetailUserControl();

            // 更改视图模型
            mainWindow.MonitorUserControl = workShopDetailUC;
        }

        // 展示详情命令
        public Command ShowDetailCmd
        {
            get
            {
                return new Command(ShowWorkShopDetailUC);
            }
        }
    }
}