namespace Gu.Wpf.Reactive
{
    using System;
    using System.Reactive.Linq;

    /// <summary>
    /// A command that does not use the CommandParameter
    /// </summary>
    public class ObservingRelayCommand : ManualRelayCommand, IDisposable
    {
        private IDisposable _subscription;

        public ObservingRelayCommand(
            Action action,
            Func<bool> condition,
            params IObservable<object>[] observable)
            : base(action, condition)
        {
            _subscription = observable.Merge()
                                      .Subscribe(x => RaiseCanExecuteChanged());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _subscription != null)
            {
                _subscription.Dispose();
                _subscription = null;
            }
        }
    }
}