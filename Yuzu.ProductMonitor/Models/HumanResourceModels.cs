using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuzu.ProductMonitor.ViewModels;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 人力资源数据
    /// </summary>
    public class HumanResourceModel : ObservableObject
    {
        private string itemName;
        public string ItemName
        {
            get => itemName;
            set
            {
                if (itemName != value)
                {
                    itemName = value; RaisePropertyChanged();
                }
            }
        }
        private int count;
        public int Count
        {
            get => count; set
            {
                if (count != value)
                {
                    count = value; RaisePropertyChanged();
                }
            }
        }
        public HumanResourceModel() { }
        public HumanResourceModel(string name, int count)
        {
            Count = count;
            ItemName = name;
        }
    }
}
