﻿namespace Divergic.Logging.Xunit
{
    using System;
    using EnsureThat;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     The <see cref="LoggerExtensions" />
    ///     class provides extension methods for wrapping <see cref="ILogger" /> instances in <see cref="ICacheLogger" />.
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        ///     Returns a <see cref="ICacheLogger" /> for the specified logger.
        /// </summary>
        /// <param name="logger">The source logger.</param>
        /// <returns>The cache logger.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="logger" /> is <c>null</c>.</exception>
        public static ICacheLogger WithCache(this ILogger logger)
        {
            Ensure.Any.IsNotNull(logger, nameof(logger));

            var cacheLogger = new CacheLogger(logger);

            return cacheLogger;
        }

        /// <summary>
        ///     Returns a <see cref="ICacheLogger{T}" /> for the specified logger.
        /// </summary>
        /// <typeparam name="T">The type of generic logger.</typeparam>
        /// <param name="logger">The source logger.</param>
        /// <returns>The cache logger.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="logger" /> is <c>null</c>.</exception>
        public static ICacheLogger<T> WithCache<T>(this ILogger<T> logger)
        {
            Ensure.Any.IsNotNull(logger, nameof(logger));

            var cacheLogger = new CacheLogger<T>(logger);

            return cacheLogger;
        }
    }
}