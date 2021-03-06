namespace Gu.Reactive.Tests.Collections.Filter
{
    using System;

    using Gu.Reactive.Tests.Helpers;

    using NUnit.Framework;

    public class FilteredViewNoScheduler : FilterTests
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _view = _ints.AsFilteredView(x => true, TimeSpan.Zero);
            _actual = _view.SubscribeAll();
        }
    }
}