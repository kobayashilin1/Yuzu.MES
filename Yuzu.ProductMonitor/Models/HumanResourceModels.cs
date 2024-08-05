using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 人力资源数据
    /// </summary>
    public class HumanResourceModel
    {
        public string ItemName { get; set; }
        public int Count { get; set; }
        public HumanResourceModel() { }
        public HumanResourceModel(string name, int count)
        {
            Count = count;
            ItemName = name;
        }
    }
}
