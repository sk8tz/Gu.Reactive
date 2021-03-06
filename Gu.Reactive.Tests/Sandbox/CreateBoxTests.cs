﻿namespace Gu.Reactive.Tests.Sandbox
{
    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using Microsoft.Reactive.Testing;
    using NUnit.Framework;

    public class CreateBoxTests
    {
        public event EventHandler Event;
        [Test, Explicit]
        public void Stucko()
        {
            var scheduler = new TestScheduler();
            var observable = Observable.Create<EventArgs>(x =>
            {
                scheduler.Schedule(TimeSpan.FromMilliseconds(15),
                                   () => x.OnNext(EventArgs.Empty));
                return Disposable.Empty;
            });
            observable.Buffer(() => observable.Throttle(TimeSpan.FromMilliseconds(10), scheduler))
                      .Subscribe(Console.WriteLine);
            scheduler.Start();
        }

        [Test]
        public void Publish()
        {
            var scheduler = new TestScheduler();
            var observable = Observable.Create<EventArgs>(x =>
            {
                EventHandler h = (_, e) =>
                {
                    x.OnNext(e);
                };
                Event += h;
                return Disposable.Create(() => Event -= h);
            });
            var shared = observable.Publish().RefCount();
            var buffering = shared.Buffer(() => shared.Throttle(TimeSpan.FromMilliseconds(15), scheduler));
            buffering.Subscribe(Console.WriteLine);
            scheduler.Schedule(TimeSpan.Zero, () => Event?.Invoke(this, EventArgs.Empty));
            scheduler.Start();
        }
    }
}
