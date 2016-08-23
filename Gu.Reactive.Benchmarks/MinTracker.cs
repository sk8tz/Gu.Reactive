namespace Gu.Reactive.Benchmarks
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    public class MinTracker : IDisposable
    {
        private readonly ObservableCollection<int> _ints = new ObservableCollection<int>(Enumerable.Range(-5, 10));
        private readonly ObservableCollection<Fake> _propertyFakes = new ObservableCollection<Fake>(Enumerable.Range(-5, 10).Select(x => new Fake { Value = x }));
        private readonly ObservableCollection<Fake> _propertyChangeFakes = new ObservableCollection<Fake>(Enumerable.Range(-5, 10).Select(x => new Fake { Value = x }));
        private readonly MinTracker<int> _valueTracker;
        private readonly MinTracker<int> _propertyTracker;
        private readonly MinTracker<int> _propertyChangeTracker;

        public MinTracker()
        {
            _valueTracker = _ints.TrackMin(-1);
            _propertyTracker = _propertyFakes.TrackMin(x => x.Value, -1, false);
            _propertyChangeTracker = _propertyChangeFakes.TrackMin(x => x.Value, -1, true);

        }

        [Benchmark]
        public int? Simple()
        {
            _ints.Add(5);
            return _valueTracker.Value;
        }

        [Benchmark]
        public int? Property()
        {
            _propertyFakes.Add(new Fake { Value = 5 });
            return _propertyTracker.Value;
        }

        [Benchmark]
        public int? WhenTrackingChanges()
        {
            _propertyChangeFakes.Add(new Fake { Value = 5 });
            return _propertyChangeTracker.Value;
        }

        public void Dispose()
        {
            _valueTracker.Dispose();
            _propertyTracker.Dispose();
            _propertyChangeTracker.Dispose();
        }
    }
}