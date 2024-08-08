using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuzu.ProductMonitor.ViewModels;

namespace Yuzu.ProductMonitor.Models
{
    public class DeviceModels : ObservableObject
    {
        private string deviceItemName;
        public string DeviceItemName
        {
            get => deviceItemName;
            set
            {
                if (deviceItemName != value)
                {
                    deviceItemName = value; RaisePropertyChanged();
                }
            }
        }

        private double deviceItemValue;
        public double DeviceItemValue
        {
            get => deviceItemValue;
            set
            {
                if (deviceItemValue != value)
                {
                    deviceItemValue = value; RaisePropertyChanged();
                }
            }
        }
    }
}
