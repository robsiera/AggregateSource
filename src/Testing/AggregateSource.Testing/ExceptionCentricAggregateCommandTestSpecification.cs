﻿using System;

namespace AggregateSource.Testing
{
    /// <summary>
    /// Represents an exception centric test specification, meaning that the outcome revolves around an exception as a result of executing a command method on an aggregate.
    /// </summary>
    public class ExceptionCentricAggregateCommandTestSpecification
    {
        readonly Func<IAggregateRootEntity> _sutFactory;
        readonly object[] _givens;
        readonly Action<IAggregateRootEntity> _when;
        readonly Exception _throws;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionCentricAggregateCommandTestSpecification"/> class.
        /// </summary>
        /// <param name="sutFactory">The sut factory.</param>
        /// <param name="givens">The events to arrange.</param>
        /// <param name="when">The command method to act upon.</param>
        /// <param name="throws">The expected exception to assert.</param>
        public ExceptionCentricAggregateCommandTestSpecification(Func<IAggregateRootEntity> sutFactory, object[] givens,
                                                                 Action<IAggregateRootEntity> when, Exception throws)
        {
            if (sutFactory == null) throw new ArgumentNullException(nameof(sutFactory));
            if (givens == null) throw new ArgumentNullException(nameof(givens));
            if (when == null) throw new ArgumentNullException(nameof(when));
            if (throws == null) throw new ArgumentNullException(nameof(throws));
            _sutFactory = sutFactory;
            _givens = givens;
            _when = when;
            _throws = throws;
        }

        /// <summary>
        /// Gets the sut factory.
        /// </summary>
        /// <value>
        /// The sut factory.
        /// </value>
        public Func<IAggregateRootEntity> SutFactory
        {
            get { return _sutFactory; }
        }

        /// <summary>
        /// The events to arrange.
        /// </summary>
        public object[] Givens
        {
            get { return _givens; }
        }

        /// <summary>
        /// The command method to act upon.
        /// </summary>
        public Action<IAggregateRootEntity> When
        {
            get { return _when; }
        }

        /// <summary>
        /// The expected exception to assert.
        /// </summary>
        public Exception Throws
        {
            get { return _throws; }
        }


        /// <summary>
        /// Returns a test result that indicates this specification has passed.
        /// </summary>
        /// <returns>A new <see cref="ExceptionCentricAggregateCommandTestResult"/>.</returns>
        public ExceptionCentricAggregateCommandTestResult Pass()
        {
            return new ExceptionCentricAggregateCommandTestResult(
                this,
                TestResultState.Passed,
                Optional<Exception>.Empty,
                Optional<object[]>.Empty);
        }

        /// <summary>
        /// Returns a test result that indicates this specification has failed because nothing happened.
        /// </summary>
        /// <returns>A new <see cref="ExceptionCentricAggregateCommandTestResult"/>.</returns>
        public ExceptionCentricAggregateCommandTestResult Fail()
        {
            return new ExceptionCentricAggregateCommandTestResult(
                this,
                TestResultState.Failed,
                Optional<Exception>.Empty,
                Optional<object[]>.Empty);
        }

        /// <summary>
        /// Returns a test result that indicates this specification has failed because different things happened.
        /// </summary>
        /// <param name="actual">The actual events</param>
        /// <returns>A new <see cref="ExceptionCentricAggregateCommandTestResult"/>.</returns>
        public ExceptionCentricAggregateCommandTestResult Fail(object[] actual)
        {
            if (actual == null) throw new ArgumentNullException(nameof(actual));
            return new ExceptionCentricAggregateCommandTestResult(
                this,
                TestResultState.Failed,
                Optional<Exception>.Empty,
                new Optional<object[]>(actual));
        }

        /// <summary>
        /// Returns a test result that indicates this specification has failed because an exception happened.
        /// </summary>
        /// <param name="actual">The actual exception</param>
        /// <returns>A new <see cref="ExceptionCentricAggregateCommandTestResult"/>.</returns>
        public ExceptionCentricAggregateCommandTestResult Fail(Exception actual)
        {
            if (actual == null) throw new ArgumentNullException(nameof(actual));
            return new ExceptionCentricAggregateCommandTestResult(
                this,
                TestResultState.Failed,
                new Optional<Exception>(actual),
                Optional<object[]>.Empty);
        }
    }
}