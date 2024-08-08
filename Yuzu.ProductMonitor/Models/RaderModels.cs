using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuzu.ProductMonitor.ViewModels;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 雷达图的Model
    /// </summary>
    public class RaderModel : ObservableObject
    {
        // 项目名称
        private string itemName;
        public string ItemName
        {
            get => itemName;
            set
            {
                if (itemName != value)
                {

                    this.itemName = value;
                    RaisePropertyChanged();
                }
            }
        }
        // 项目值
        private double itemValue;
        public double ItemValue
        {
            get => itemValue;
            set
            {
                if (itemValue != value)
                {
                    itemValue = value; RaisePropertyChanged();
                }
            }
        }
    }
}
