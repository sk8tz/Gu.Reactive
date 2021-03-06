﻿namespace Gu.Reactive
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;

    public static class ConditionExt
    {
        //private static readonly ConditionalWeakTable<ISatisfied, IObservable<ISatisfied>> Cache = new ConditionalWeakTable<ISatisfied, IObservable<ISatisfied>>();

        public static IObservable<T> ObserveIsSatisfiedChanged<T>(this T condition) where T: class, ISatisfied
        {
            var observable = Observable.Create<T>(
                o =>
                {
                    PropertyChangedEventHandler handler = (_, e) =>
                    {
                        if (e.PropertyName == nameof(condition.IsSatisfied))
                        {
                            o.OnNext(condition);
                        }
                    };
                    condition.PropertyChanged += handler;
                    return Disposable.Create(() => condition.PropertyChanged -= handler);
                });
            return observable;
        }

        public static bool IsInSync(this ICondition condition)
        {
            return condition.IsSatisfied == condition.History
                                                     .Last()
                                                     .State;
        }

        //private static IObservable<T> CreateCondition<T>(T condition) where T : class, ISatisfied
            //{
            //    var observable = Observable.Create<T>(
            //        o =>
            //        {
            //            PropertyChangedEventHandler handler = (_, e) =>
            //            {
            //                if (e.PropertyName == nameof(condition.IsSatisfied))
            //                {
            //                    o.OnNext(condition);
            //                }
            //            };
            //            condition.PropertyChanged += handler;
            //            return Disposable.Create(() => condition.PropertyChanged -= handler);
            //        });
            //    return observable;
            //}
        }
}
