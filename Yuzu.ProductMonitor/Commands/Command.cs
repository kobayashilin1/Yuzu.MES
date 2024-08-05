using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Yuzu.ProductMonitor.Commands
{
    public class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        // 定义委托
        private Action action;
        public Action Action { get { return action; } }

        // 构造方法
        public Command(Action action)
        {
            this.action = action;
        }

        // 是否可执行
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (action != null) 
            { 
                this.action();
            }
        }
    }
}
