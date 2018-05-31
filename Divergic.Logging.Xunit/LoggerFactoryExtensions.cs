﻿namespace Microsoft.Extensions.Logging
{
    using System;
    using Divergic.Logging.Xunit;
    using EnsureThat;
    using Xunit.Abstractions;

    /// <summary>
    ///     The <see cref="LoggerFactoryExtensions" />
    ///     class provides extension methods for configuring <see cref="ILoggerFactory" /> with providers.
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// Registers the <see cref="TestOutputLoggerProvider"/> in the factory using the specified <see cref="ITestOutputHelper"/>.
        /// </summary>
        /// <param name="factory">The factory to add the provider to.</param>
        /// <param name="output">The test output reference.</param>
        /// <returns>The logger factory.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="factory"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="output"/> is <c>null</c>.</exception>
        public static ILoggerFactory UseXunit(this ILoggerFactory factory, ITestOutputHelper output)
        {
            Ensure.Any.IsNotNull(factory, nameof(factory));
            Ensure.Any.IsNotNull(output, nameof(output));

            var provider = new TestOutputLoggerProvider(output);

            factory.AddProvider(provider);

            return factory;
        }
    }
}