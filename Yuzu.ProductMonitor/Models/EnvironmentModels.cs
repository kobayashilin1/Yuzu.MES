using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuzu.ProductMonitor.ViewModels;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 环境数据模型
    /// </summary>
    public class EnvironmentModel : ObservableObject
    {
        // 环境项的名称
        private string environmentItemName;
        public string EnvironmentItemName
        {
            get => environmentItemName; 
            set
            {
                if (environmentItemName != value)
                {
                    environmentItemName = value;
                    RaisePropertyChanged();
                }
            }
        }

        // 环境项的值
        private int environmentItemValue;
        public int EnvironmentItemValue
        {
            get => environmentItemValue; 
            set
            {
                if (environmentItemValue != value)
                {
                    {
                        environmentItemValue = value; RaisePropertyChanged();
                    }
                }
            }
        }
    }
}
