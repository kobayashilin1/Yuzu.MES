using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Yuzu.ProductMonitor.UserControls;

namespace Yuzu.ProductMonitor.ViewModels
{
    /// <summary>
    /// 主界面的视图模型（ViewModel）
    /// </summary>
    public class MainWindowVM : ObservableObject
    {
        private readonly DispatcherTimer timer = new DispatcherTimer();

        private string time = string.Empty;
        public string Time
        {
            get => time;
            set 
            { 
                if (time != value) { time = value; RaisePropertyChanged(); } 
            }
        }

        private string date = string.Empty;
        public string Date
        {
            get => date;
            set 
            { 
                if (date != value) { date = value; RaisePropertyChanged(); } 
            }
        }

        private string weekDay = string.Empty;
        public string WeekDay
        {
            get => weekDay;
            set
            {
                if (weekDay != value) { weekDay = value; RaisePropertyChanged(); }
            }
        }

        // 初始化计时器
        private void InitializeTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) =>
            {
                Time = DateTime.Now.ToString("HH:mm:ss");
                Date = DateTime.Now.ToString("yyyy:MM:dd");
                WeekDay = DateTime.Now.ToString("dddd");
            };
            timer.Start();
        }

        // 监视用户控件：因为以后会定义别的控件，所以类型统一使用 UserControl
        private UserControl? monitorUserControl;
        public UserControl? MonitorUserControl
        {
            get
            {
                // 若为空，则实例化一个 UserContro 控件
                return monitorUserControl;
            }
            set
            {
                monitorUserControl = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowVM()
        {
            MonitorUserControl = new MonitorUserControl();
            InitializeTimer();
        }
    }
}
