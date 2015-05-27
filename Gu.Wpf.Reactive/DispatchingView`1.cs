namespace Gu.Wpf.Reactive
{
    using System;
    using System.Collections.ObjectModel;

    public class DispatchingView<T> : ObservableCollectionWrapperBase<ObservableCollection<T>, T>
    {
        public DispatchingView(ObservableCollection<T> inner)
            : base(inner)
        {
            InnerCollectionChangedObservable.Subscribe(x => OnCollectionChanged(x.EventArgs));
            InnerCountChangedObservable.Subscribe(x => OnPropertyChanged(x.EventArgs));
            InnerIndexerChangedObservable.Subscribe(x => OnPropertyChanged(x.EventArgs));
        }
    }
}
