namespace Gu.Wpf.Reactive
{
    using System;
    using System.Windows.Input;

    public class RelayCommand<T> : ManualRelayCommand<T>
    {
        public RelayCommand(Action<T> action, Func<T, bool> condition)
            : base(action, condition, true)
        {
        }

        public RelayCommand(Action<T> action)
            : this(action, o => true)
        {
        }

        /// <summary>
        /// http://stackoverflow.com/a/2588145/1069200
        /// </summary>
        public override event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                base.CanExecuteChanged += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                base.CanExecuteChanged -= value;
            }
        }
    }

    public class RelayCommand : ManualRelayCommand
    {
        public RelayCommand(Action action, Func<bool> condition)
            : base(action, condition, true)
        {
        }

        public RelayCommand(Action action)
            : this(action, () => true)
        {
        }

        /// <summary>
        /// http://stackoverflow.com/a/2588145/1069200
        /// </summary>
        public override event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                base.CanExecuteChanged += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                base.CanExecuteChanged -= value;
            }
        }
    }
}