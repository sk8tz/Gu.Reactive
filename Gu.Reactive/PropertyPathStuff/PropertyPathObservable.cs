﻿namespace Gu.Reactive.PropertyPathStuff
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reactive;
    using System.Reactive.Disposables;

    /// <summary>
    /// The nested observable.
    /// </summary>
    /// <typeparam name="TClass">
    /// </typeparam>
    /// <typeparam name="TProp">
    /// </typeparam>
    internal sealed class PropertyPathObservable<TClass, TProp> :
        ObservableBase<EventPattern<PropertyChangedEventArgs>>
        where TClass : INotifyPropertyChanged
    {
        internal readonly PropertyChangedEventArgs PropertyChangedEventArgs;
        private readonly WeakReference _sourceReference = new WeakReference(null);
        private bool _disposed;
        private readonly PropertyPath<TClass, TProp> _propertyPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyPathObservable{TClass,TProp}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="propertyExpression">
        /// The property expression.
        /// </param>
        public PropertyPathObservable(TClass source, Expression<Func<TClass, TProp>> propertyExpression)
            : this(source, PropertyPath.Create(propertyExpression))
        {
        }

        public PropertyPathObservable(TClass source, PropertyPath<TClass,TProp> propertyPath )
        {
            _sourceReference.Target = source;
            _propertyPath = propertyPath;
            VerifyPath(_propertyPath);
            PropertyChangedEventArgs = new PropertyChangedEventArgs(_propertyPath.Last.PropertyInfo.Name);
        }

        public object Sender
        {
            get { return _propertyPath.GetSender((TClass)_sourceReference.Target); }
        }

        protected override IDisposable SubscribeCore(IObserver<EventPattern<PropertyChangedEventArgs>> observer)
        {
            VerifyDisposed();
            var rootItem = new RootItem((INotifyPropertyChanged)_sourceReference.Target);
            var path = new NotifyingPath(rootItem, _propertyPath);

            var subscription = path.Last()
                                   .ObservePropertyChanged()
                                   .Subscribe(observer.OnNext, observer.OnError);
            return new CompositeDisposable(2) { path, subscription };
        }

        /// <summary>
        /// All steps in the path must implement INotifyPropertyChanged, this throws if this condition is not met.
        /// </summary>
        /// <param name="path">
        /// </param>
        private static void VerifyPath(IPropertyPath path)
        {
            for (int i = 0; i < path.Count; i++)
            {
                var propertyInfo = path[i].PropertyInfo;
                if ((i != path.Count - 1) && propertyInfo.PropertyType.IsValueType)
                {
                    throw new ArgumentException(
                        "Property path cannot have structs in it. Copy by value will make subscribing error prone. Also mutable struct much?");
                }
                if (!ImplementsINotifyPropertyChanged(propertyInfo.DeclaringType))
                {
                    throw new ArgumentException(
                        string.Format(
                            "All levels in the path must notify (DeclaringType is INotifyPropertyChanged) the type {0} does not so {0}.{1} will not notify.",
                            propertyInfo.DeclaringType.Name,
                            propertyInfo.Name));
                }
            }
        }

        private static bool ImplementsINotifyPropertyChanged(Type type)
        {
            return type.GetInterfaces()
                       .Contains(typeof(INotifyPropertyChanged));
        }

        private void VerifyDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(
                    GetType()
                        .FullName);
            }
        }
    }
}