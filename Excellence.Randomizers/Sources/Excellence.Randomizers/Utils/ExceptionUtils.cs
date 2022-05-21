﻿using System;

namespace Excellence.Randomizers.Utils
{
    /// <summary>
    /// The exception utils.
    /// </summary>
    public static class ExceptionUtils
    {
        /// <summary>
        /// Checks if the argument is <see langword="null"/>.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <typeparam name="TParam">The <see cref="param"/> type.</typeparam>
        /// <returns><see langword="true"/> when the argument is <see langword="null"/> or <see langword="false"/> when it isn't.</returns>
        public static bool IsNull<TParam>(TParam? param) where TParam : class => param == null;

        /// <summary>
        /// Throws exception when the condition is met.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="exceptionFactory">The exception factory.</param>
        /// <typeparam name="TParam">The parameter type.</typeparam>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        /// <exception cref="Exception">The exception type created by the exception factory.</exception>
        public static void Process<TParam>(TParam param, Func<TParam, bool> predicate, Func<Exception> exceptionFactory)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (exceptionFactory == null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            Process(() => predicate.Invoke(param), exceptionFactory);
        }

        /// <summary>
        /// Throws exception when the condition is met.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="exceptionFactory">The exception factory.</param>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        /// <exception cref="Exception">The exception type created by the exception factory.</exception>
        public static void Process(Func<bool> predicate, Func<Exception> exceptionFactory)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            if (exceptionFactory == null)
            {
                throw new ArgumentNullException(nameof(exceptionFactory));
            }

            if (predicate.Invoke())
            {
                throw exceptionFactory.Invoke();
            }
        }
    }
}
