﻿using System;
using AggregateSource.Testing.Command;

namespace AggregateSource.Testing
{
    /// <summary>
    /// A given-when-then test specification bootstrapper for testing an aggregate command, i.e. a method on the aggregate that returns void.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The type of aggregate root entity under test.</typeparam>
    public class CommandScenarioFor<TAggregateRoot> : IAggregateCommandInitialStateBuilder<TAggregateRoot>
        where TAggregateRoot : IAggregateRootEntity
    {
        readonly Func<IAggregateRootEntity> _sutFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandScenarioFor{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="sut">The sut.</param>
        public CommandScenarioFor(TAggregateRoot sut)
            : this(() => sut) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandScenarioFor{TAggregateRoot}"/> class.
        /// </summary>
        /// <param name="sutFactory">The sut factory.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="sutFactory"/> is <c>null</c>.</exception>
        public CommandScenarioFor(Func<TAggregateRoot> sutFactory)
        {
            if (sutFactory == null) throw new ArgumentNullException(nameof(sutFactory));
            _sutFactory = () => sutFactory();
        }

        /// <summary>
        /// Given the following events occured.
        /// </summary>
        /// <param name="events">The events that occurred.</param>
        /// <returns>A builder continuation.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="events"/> are <c>null</c>.</exception>
        public IAggregateCommandGivenStateBuilder<TAggregateRoot> Given(params object[] events)
        {
            if (events == null) throw new ArgumentNullException(nameof(events));
            return new AggregateCommandGivenStateBuilder<TAggregateRoot>(_sutFactory, events);
        }

        /// <summary>
        /// Given no events occured.
        /// </summary>
        /// <returns>A builder continuation.</returns>
        public IAggregateCommandGivenNoneStateBuilder<TAggregateRoot> GivenNone()
        {
            return new AggregateCommandGivenNoneStateBuilder<TAggregateRoot>(_sutFactory);
        }

        /// <summary>
        /// When a command occurs.
        /// </summary>
        /// <param name="command">The command method invocation on the sut.</param>
        /// <returns>A builder continuation.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="command"/> is <c>null</c>.</exception>
        public IAggregateCommandWhenStateBuilder When(Action<TAggregateRoot> command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            return new AggregateCommandWhenStateBuilder(_sutFactory, new object[0],
                                                        root => command((TAggregateRoot) root));
        }
    }
}