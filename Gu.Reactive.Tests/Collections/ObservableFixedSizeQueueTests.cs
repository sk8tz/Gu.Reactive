﻿namespace Gu.Reactive.Tests.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using Gu.Reactive;
    using Gu.Reactive.Tests.Fakes;
    using Gu.Reactive.Tests.Helpers;
    using NUnit.Framework;

    public class ObservableFixedSizeQueueTests
    {
        [Test]
        public void EnqueueWhenEmpty()
        {
            var queue = new ObservableFixedSizeQueue<int>(2);
            var actual = queue.SubscribeAll();
            queue.Enqueue(1);
            CollectionAssert.AreEqual(new[] { 1 }, queue);
            var expected = Diff.CreateAddEventArgsCollection(1, 0);
            CollectionAssert.AreEqual(expected, actual, EventArgsComparer.Default);
        }

        [Test]
        public void EnqueueWhenHasOne()
        {
            var queue = new ObservableFixedSizeQueue<int>(2);
            queue.Enqueue(1);
            var actual = queue.SubscribeAll();
            queue.Enqueue(2);
            CollectionAssert.AreEqual(new[] { 1,2 }, queue);
            var expected = Diff.CreateAddEventArgsCollection(2, 1);
            CollectionAssert.AreEqual(expected, actual, EventArgsComparer.Default);
        }

        [Test]
        public void EnqueueTrimsOverflowAndNotifies()
        {
            var queue = new ObservableFixedSizeQueue<int>(2);
            queue.Enqueue(1);
            queue.Enqueue(2);
            var actual = queue.SubscribeAll();
            queue.Enqueue(3);
            CollectionAssert.AreEqual(new[] { 2, 3 }, queue);
            var expected = new EventArgs[]
            {
                Diff.IndexerPropertyChangedEventArgs,
                Diff.CreateRemoveEventArgs(1, 0),
                Diff.CreateAddEventArgs(3, 1)
            };

            CollectionAssert.AreEqual(expected, actual, EventArgsComparer.Default);
        }
    }
}
