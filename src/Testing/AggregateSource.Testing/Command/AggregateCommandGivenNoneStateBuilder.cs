﻿using System;

namespace AggregateSource.Testing.Command
{
    class AggregateCommandGivenNoneStateBuilder<TAggregateRoot> : IAggregateCommandGivenNoneStateBuilder<TAggregateRoot> 
        where TAggregateRoot : IAggregateRootEntity
    {
        readonly Func<IAggregateRootEntity> _sutFactory;

        public AggregateCommandGivenNoneStateBuilder(Func<IAggregateRootEntity> sutFactory)
        {
            _sutFactory = sutFactory;
        }

        public IAggregateCommandWhenStateBuilder When(Action<TAggregateRoot> command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            return new AggregateCommandWhenStateBuilder(_sutFactory, new object[0], root => command((TAggregateRoot)root));
        }
    }
}