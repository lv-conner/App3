using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App3.Command
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event Action<object> ExecteCommand;
        public event Func<object, bool> CanExecuteCommand;
        public bool CanExecute(object parameter)
        {
            if(CanExecuteCommand!= null)
            {
                return CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }
        public void Execute(object parameter)
        {
            ExecteCommand?.Invoke(parameter);
        }
    }
}
