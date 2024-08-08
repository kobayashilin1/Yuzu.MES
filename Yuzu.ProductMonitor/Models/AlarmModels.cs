using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuzu.ProductMonitor.ViewModels;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 报警数据模型
    /// </summary>
    public class AlarmModel : ObservableObject
    {
        // 编号
        private string code;
        public string Code
        {
            get => code;
            set
            {
                if (code != value)
                {
                    code = value; RaisePropertyChanged();
                }
            }
        }

        // 信息
        private string message;
        public string Message
        {
            get => message;
            set
            {

                if (message != value)
                {
                    message = value; RaisePropertyChanged();
                }
            }
        }

        // 时间
        private string time;
        public string Time
        {
            get => time; set
            {
                if (time != value)
                {
                    time = value; RaisePropertyChanged();
                }
            }
        }

        // 报警时长(s)
        private int duration;
        public int Duration
        {
            get => duration; 
            set
            {
                if (duration != value)
                {
                    duration = value; RaisePropertyChanged();

                }
            }
        }

    }
}
