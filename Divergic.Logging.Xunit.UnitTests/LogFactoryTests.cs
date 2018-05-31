﻿namespace Divergic.Logging.Xunit.UnitTests
{
    using System;
    using FluentAssertions;
    using global::Xunit;
    using global::Xunit.Abstractions;
    using Microsoft.Extensions.Logging;
    using ModelBuilder;

    public class LogFactoryTests
    {
        private readonly ITestOutputHelper _output;

        public LogFactoryTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void BuildLogForReturnsCacheLoggerTTest()
        {
            var logLevel = LogLevel.Error;
            var eventId = Model.Create<EventId>();
            var state = Guid.NewGuid().ToString();
            var data = Guid.NewGuid().ToString();
            var exception = new ArgumentNullException(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            Func<string, Exception, string> formatter = (message, error) => data;

            var sut = LogFactory.BuildLogFor<LogFactoryTests>(_output);

            sut.Log(logLevel, eventId, state, exception, formatter);

            sut.Should().BeAssignableTo<ICacheLogger<LogFactoryTests>>();
            sut.Count.Should().Be(1);
        }

        [Fact]
        public void BuildLogForThrowsExceptionWithNullOutputTest()
        {
            Action action = () => LogFactory.BuildLogFor<LogFactoryTests>(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void BuildLogReturnsCacheLoggerTest()
        {
            var logLevel = LogLevel.Error;
            var eventId = Model.Create<EventId>();
            var state = Guid.NewGuid().ToString();
            var data = Guid.NewGuid().ToString();
            var exception = new ArgumentNullException(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            Func<string, Exception, string> formatter = (message, error) => data;

            var sut = LogFactory.BuildLog(_output);

            sut.Log(logLevel, eventId, state, exception, formatter);

            sut.Should().BeAssignableTo<ICacheLogger>();
            sut.Count.Should().Be(1);
        }

        [Fact]
        public void BuildLogThrowsExceptionWithNullOutputTest()
        {
            Action action = () => LogFactory.BuildLog(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateReturnsFactoryTest()
        {
            var sut = LogFactory.Create(_output);

            var logger = sut.CreateLogger<LogFactoryTests>();

            logger.LogInformation("This should be written to the test out");
        }

        [Fact]
        public void CreateThrowsExceptionWithNullOutputTest()
        {
            Action action = () => LogFactory.Create(null);

            action.Should().Throw<ArgumentNullException>();
        }
    }
}