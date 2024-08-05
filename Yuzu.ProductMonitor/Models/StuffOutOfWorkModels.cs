using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 员工缺岗数据
    /// </summary>
    public class StuffOutOfWorkModel
    {
        // 员工姓名
        public string StuffName { get; set; }
        // 职位
        public string PositionName { get; set; }
        // 缺席时间(min)
        public int OutOfWorkCount { get; set; }
        public StuffOutOfWorkModel() { }
        public StuffOutOfWorkModel(StuffOutOfWorkModel otherStuff)
        {
            StuffName = otherStuff.StuffName;
            PositionName = otherStuff.PositionName;
            OutOfWorkCount = otherStuff.OutOfWorkCount;
        }
    }
}
