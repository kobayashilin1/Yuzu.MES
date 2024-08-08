using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuzu.ProductMonitor.ViewModels;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 车间数据模型
    /// </summary>
    public class WorkShopModel : ObservableObject
    {
        // 车间名称
        private string workShopName;
        public string WorkShopName
        {
            get => workShopName;
            set
            {
                if (workShopName != value)
                {
                    workShopName = value;
                    RaisePropertyChanged();
                }
            }
        }

        // 作业数量
        private int workingCount;
        public int WorkingCount
        {
            get => workingCount;
            set
            {
                workingCount = value; RaisePropertyChanged();
            }
        }

        // 等待数量
        private int waitingCount;
        public int WaitingCount
        {
            get => waitingCount;
            set
            {
                waitingCount = value; RaisePropertyChanged();
            }
        }

        // 故障数量
        private int errorCount;
        public int ErrorCount
        {
            get => errorCount;
            set
            {
                if (errorCount != value)
                {
                    errorCount = value; RaisePropertyChanged();
                }
            }
        }

        // 停机数量
        public int StopCount { get; set; }

        // 总数量
        public int TotalCount
        {
            get
            {
                return WorkingCount + WaitingCount + ErrorCount + StopCount;
            }
        }
    }
}
