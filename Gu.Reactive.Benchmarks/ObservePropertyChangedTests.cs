namespace Gu.Reactive.Benchmarks
{
    using System;
    using System.ComponentModel;
    using System.Reactive;
    using System.Reactive.Linq;

    using BenchmarkDotNet.Attributes;

    using Gu.Reactive.PropertyPathStuff;

    public class ObservePropertyChanged
    {
        private static readonly Fake Fake = new Fake { IsTrueOrNull = false, IsTrue = true, Next = new Level { Name = "" } };

        private static readonly PropertyPath<Fake, string> PropertyPath = PropertyPathStuff.PropertyPath.Create<Fake, string>(x => x.Next.Name);

        [Benchmark(Baseline = true)]
        public int PropertyChanged()
        {
            int count = 0;
            Fake.PropertyChanged += (sender, args) =>
            {
                if (string.IsNullOrEmpty(args.PropertyName) || args.PropertyName == nameof(Fake.IsTrue))
                {
                    count++;
                }
            };

            Fake.IsTrue = !Fake.IsTrue;
            return count;
        }

        [Benchmark]
        public IObservable<EventPattern<PropertyChangedEventArgs>> ObservePropertyChangedSimple()
        {
            return Fake.ObservePropertyChanged(x => x.IsTrueOrNull, false);
        }

        [Benchmark]
        public IObservable<EventPattern<PropertyChangedEventArgs>> ObservePropertyChangedNested()
        {
            return Fake.ObservePropertyChanged(x => x.Next.Name, false);
        }

        [Benchmark]
        public IObservable<EventPattern<PropertyChangedEventArgs>> ObservePropertyChangedNestedCachedPath()
        {
            return Fake.ObservePropertyChanged(PropertyPath, false);
        }

        [Benchmark]
        public IDisposable SubscribeSimple()
        {
            return Fake.ObservePropertyChanged(x => x.IsTrueOrNull, false).Subscribe();
        }

        [Benchmark]
        public IDisposable SubscribeNested()
        {
            return Fake.ObservePropertyChanged(x => x.Next.Name, false).Subscribe(x=> {});
        }

        [Benchmark]
        public int ReactSimple()
        {
            int count = 0;
            var fake = new Fake { IsTrueOrNull = false, IsTrue = true };
            using (fake.ObservePropertyChanged(x => x.IsTrueOrNull, false).Subscribe(x => count++))
            {
                fake.IsTrueOrNull = !fake.IsTrueOrNull;
                return count;
            }
        }

        [Benchmark]
        public int ReactNested()
        {
            int count = 0;
            using (Fake.ObservePropertyChanged(x => x.Next.IsTrue, false)
                       .Subscribe(x => count++))
            {
                Fake.Next.IsTrue = !Fake.Next.IsTrue;
                return count;
            }
        }

        [Benchmark]
        public int RxObserveThenSubscribe()
        {
            int count = 0;
            using (Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(x => Fake.PropertyChanged += x, x => Fake.PropertyChanged -= x)
                                              .Where(x => x.EventArgs.PropertyName == nameof(Fake.IsTrue))
                                              .Subscribe(x => count++))
            {
                Fake.IsTrue = !Fake.IsTrue;
                return count;
            }
        }

        [Benchmark]
        public void PropertyChangedEventManager()
        {
            int count = 0;
            System.ComponentModel.PropertyChangedEventManager.AddHandler(Fake, (sender, args) => count++, nameof(Fake.IsTrue));
            Fake.IsTrue = !Fake.IsTrue;
        }
    }
}
