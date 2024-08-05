using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 车间数据模型
    /// </summary>
    public class WorkShopModel
    {
        // 车间名称
        public string WorkShopName { get; set; }

        // 作业数量
        public int WorkingCount { get; set; }

        // 等待数量
        public int WaitingCount { get; set; }

        // 故障数量
        public int ErrorCount { get; set; }

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
