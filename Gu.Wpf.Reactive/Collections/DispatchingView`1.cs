﻿namespace Gu.Wpf.Reactive
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;

    using Gu.Reactive;

    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    [DebuggerDisplay("Count = {Count}")]
    public class DispatchingView<T> : ThrottledView<T>
    {
        public DispatchingView(ObservableCollection<T> source)
            : base(source, TimeSpan.Zero, WpfSchedulers.Dispatcher)
        {
        }

        public DispatchingView(ObservableCollection<T> source, TimeSpan bufferTime)
            : base(source, bufferTime, WpfSchedulers.Dispatcher)
        {
        }

        public DispatchingView(IObservableCollection<T> source)
            : base(source, TimeSpan.Zero, WpfSchedulers.Dispatcher)
        {
        }

        public DispatchingView(IObservableCollection<T> source, TimeSpan bufferTime)
            : base(source, bufferTime, WpfSchedulers.Dispatcher)
        {
        }
    }
}
