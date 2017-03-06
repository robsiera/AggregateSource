﻿using System;

namespace AggregateSource.Testing.Command
{
    class AggregateCommandWhenStateBuilder : IAggregateCommandWhenStateBuilder
    {
        readonly Func<IAggregateRootEntity> _sutFactory;
        readonly object[] _givens;
        readonly Action<IAggregateRootEntity> _when;

        public AggregateCommandWhenStateBuilder(Func<IAggregateRootEntity> sutFactory, object[] givens,
                                                Action<IAggregateRootEntity> when)
        {
            _sutFactory = sutFactory;
            _givens = givens;
            _when = when;
        }

        public IAggregateCommandThenNoneStateBuilder ThenNone()
        {
            return new AggregateCommandThenNoneStateBuilder(_sutFactory, _givens, _when);
        }

        public IAggregateCommandThenStateBuilder Then(params object[] events)
        {
            if (events == null) throw new ArgumentNullException(nameof(events));
            return new AggregateCommandThenStateBuilder(_sutFactory, _givens, _when, events);
        }

        public IAggregateCommandThrowStateBuilder Throws(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            return new AggregateCommandThrowStateBuilder(_sutFactory, _givens, _when, exception);
        }
    }
}