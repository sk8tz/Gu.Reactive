namespace Gu.Reactive.Tests.Collections.CrudView
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;

    using Gu.Reactive;
    using Gu.Reactive.Tests.Helpers;

    using Microsoft.Reactive.Testing;

    using NUnit.Framework;

    public abstract class CrudViewTests
    {
        private List<EventArgs> _expected;
        protected List<EventArgs> _actual;
        protected TestScheduler _scheduler;
        protected IFilteredView<int> _view;
        protected ObservableCollection<int> _ints;

        [SetUp]
        public virtual void SetUp()
        {
            _ints = new ObservableCollection<int>(new[] { 1, 2, 3 });
            _expected = SubscribeAll(_ints);
        }

        [TearDown]
        public void TearDown()
        {
            _view.Dispose();
        }

        [Test]
        public void NoChangeNoEvent()
        {
            CollectionAssert.AreEqual(_ints, _view);

            _view.Refresh();
            _scheduler?.Start();
            CollectionAssert.AreEqual(_ints, _view);
            CollectionAssert.IsEmpty(_actual);
        }

        [Test]
        public void UpdatesBeforeItNotifies()
        {
            int[] actual = null;
            int[] expected = null;
            _view.ObserveCollectionChanged(false)
                 .Subscribe(_ => { actual = _view.ToArray(); });
            _ints.ObserveCollectionChanged(false)
                 .Subscribe(_ => { expected = _ints.ToArray(); });
            _view.Add(5);
            _scheduler?.Start();
            CollectionAssert.AreEqual(expected, actual);

            _view.Clear();
            _scheduler?.Start();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Add()
        {
            _view.Add(4);
            _scheduler?.Start();
            CollectionAssert.AreEqual(_ints, _view);
            CollectionAssert.AreEqual(_expected, _actual, EventArgsComparer.Default);
        }

        [Test]
        public void IListAdd()
        {
            // DataGrid adds items like this
            var index = ((IList)_view).Add(4);
            _scheduler?.Start();
            Assert.AreEqual(3, index);
            CollectionAssert.AreEqual(_ints, _view);
            CollectionAssert.IsNotEmpty(_actual);
            CollectionAssert.AreEqual(_expected, _actual, EventArgsComparer.Default);

            var before = _actual.ToArray();
            _scheduler?.Start(); // Should not signal deferred

            CollectionAssert.AreEqual(before, _actual, EventArgsComparer.Default);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Remove(int toRemove)
        {
            _view.Remove(toRemove);
            _scheduler?.Start();
            CollectionAssert.AreEqual(_ints, _view);
            CollectionAssert.AreEqual(_expected, _actual, EventArgsComparer.Default);
        }

        [TestCase(2, 5)]
        [TestCase(0, 5)]
        public void ReplaceIndexer(int index, int value)
        {
            _view[index] = value;
            _scheduler?.Start();
            Assert.AreEqual(value, _view[index]);
            CollectionAssert.AreEqual(_ints, _view);
            CollectionAssert.AreEqual(_expected, _actual, EventArgsComparer.Default);
        }

        [TestCase(0, 1)]
        public void Move(int fromIndex, int toIndex)
        {
            Assert.Inconclusive("Do we want move?");
            //_view.Move(fromIndex, toIndex);
            _scheduler?.Start();
            CollectionAssert.AreEqual(_ints, _view);
            CollectionAssert.AreEqual(_expected, _actual, EventArgsComparer.Default);
        }

        [Test]
        public void Count()
        {
            Assert.AreEqual(3, _view.Count);
        }

        [Test]
        public void ToArrayTest()
        {
            CollectionAssert.AreEqual(_ints, _view.ToArray());
        }

        protected List<EventArgs> SubscribeAll<T>(T view)
            where T : IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
        {
            var changes = new List<EventArgs>();
            view.ObserveCollectionChanged(false)
                .Subscribe(x => changes.Add(x.EventArgs));
            view.ObservePropertyChanged()
                .Subscribe(x => changes.Add(x.EventArgs));
            return changes;
        }
    }
}