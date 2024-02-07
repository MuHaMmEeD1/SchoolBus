using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBusWpfProje.RealyCommands
{
    public class MyRealyCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        private Action<object?> Action;
        private Predicate<object?> Predicate;

        public MyRealyCommand(Action<object?> action, Predicate<object?> predicate = null)
        {
            Action = action;
            Predicate = predicate;
        }

        public bool CanExecute(object? parameter)
        {
            if (Predicate is null) return true;
            return Predicate.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            Action.Invoke(parameter);
        }
    }
}
