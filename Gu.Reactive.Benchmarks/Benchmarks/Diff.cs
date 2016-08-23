namespace Gu.Reactive.Benchmarks
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    using BenchmarkDotNet.Attributes;

    public class Diff
    {
        private const int N = 1000;

        private static readonly List<Fake> X = Enumerable.Range(0, N)
                                                         .Select(x => new Fake { Value = x })
                                                         .ToList();

        private static readonly List<Fake> Y = Enumerable.Range(0, N)
                                                 .Select(x => new Fake { Value = x })
                                                 .ToList();
        [Benchmark]
        public NotifyCollectionChangedEventArgs CollectionChange1000()
        {
            return Reactive.Diff.CollectionChange(X, Y);
        }
    }
}