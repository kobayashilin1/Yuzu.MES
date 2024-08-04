using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuzu.ProductMonitor.Models
{
    /// <summary>
    /// 环境数据模型
    /// </summary>
    public class EnvironmentModel
    {
        // 环境项的名称
        public string EnvironmentItemName { get; set; }
        // 环境项的值
        public int EnvironmentItemValue { get; set; }
    }
}
