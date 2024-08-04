using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 报警数据模型
    /// </summary>
    public class AlarmModel
    {
        // 编号
        public string Code { get; set; }

        // 信息
        public string Message {  get; set; }

        // 时间
        public string Time {  get; set; }

        // 报警时长(s)
        public int Duration { get; set; }

    }
}
