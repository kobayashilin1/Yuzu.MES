using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuzu.ProductMonitor.ViewModels;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 员工缺岗数据
    /// </summary>
    public class StuffOutOfWorkModel : ObservableObject
    {
        // 员工姓名
        private string stuffName;
        public string StuffName
        {
            get => stuffName;
            set
            {
                if (stuffName != value)
                {
                    stuffName = value;
                    RaisePropertyChanged();
                }
            }
        }
        // 职位
        public string positionName;
        public string PositionName
        {
            get => positionName; 
            set
            {
                if (positionName != value)
                {
                    positionName = value; RaisePropertyChanged();
                }
            }
        }
        // 缺席时间(min)
        public int outOfWorkCount;
        public int OutOfWorkCount
        {
            get => outOfWorkCount; 
            set
            {
                if (outOfWorkCount != value)
                {
                    outOfWorkCount = value; RaisePropertyChanged();
                }
            }
        }
        // 显示宽度
        public double ShowWidth { get => OutOfWorkCount * 0.6; }
        public StuffOutOfWorkModel() { }
        public StuffOutOfWorkModel(StuffOutOfWorkModel otherStuff)
        {
            StuffName = otherStuff.StuffName;
            PositionName = otherStuff.PositionName;
            OutOfWorkCount = otherStuff.OutOfWorkCount;
        }
    }
}
