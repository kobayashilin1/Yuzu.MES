using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Yuzu.ProductMonitor.UserControls;

namespace Yuzu.ProductMonitor.ViewModels
{
    /// <summary>
    /// 主界面的视图模型（ViewModel）
    /// </summary>
    public class MainWindowVM : ObservableObject
    {
        // 监视用户控件：因为以后会定义别的控件，所以类型统一使用 UserControl
        private UserControl? monitorUserControl;
        public UserControl? MonitorUserControl
        {
            get
            {
                // 若为空，则实例化一个 UserContro 控件
                return monitorUserControl ?? new MonitorUserControl();
            }
            set
            {
                monitorUserControl = value;
                RaisePropertyChanged();
            }
        }
    }
}
