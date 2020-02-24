using Microsoft.Extensions.Logging;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace SampleAvaloniaApplication.Client
{
    public static class ObservableExtensions
    {
        /// <summary>
        /// Send errors to stderr
        /// </summary>
        public static IDisposable SubscribeWithLog<T>(this IObservable<T> observable, Action<T> onNext, Action onCompleted)
        {
            var logger = Locator.Current.GetService<ILogger>();

            return observable.Subscribe(
                onNext,
                e => logger.LogError(e, "Unhandled exception occured on observable"),
                onCompleted);
        }

        /// <summary>
        /// Send errors to stderr
        /// </summary>
        public static IDisposable SubscribeWithLog<T>(this IObservable<T> observable, Action onCompleted)
        {
            var logger = Locator.Current.GetService<ILogger>();

            return observable.Subscribe(
                _ => { },
                e => logger.LogError(e, "Unhandled exception occured on observable"),
                onCompleted);
        }

        /// <summary>
        /// Send errors to stderr
        /// </summary>
        public static IDisposable SubscribeWithLog<T>(this IObservable<T> observable, Action<T> onNext)
        {
            var logger = Locator.Current.GetService<ILogger>();

            return observable.Subscribe(
                onNext,
                e => logger.LogError(e, "Unhandled exception occured on observable"));
        }

        /// <summary>
        /// Send errors to stderr
        /// </summary>
        public static IDisposable SubscribeWithLog<T>(this IObservable<T> observable)
        {
            var logger = Locator.Current.GetService<ILogger>();

            return observable.Subscribe(
                _ => { },
                e => logger.LogError(e, "Unhandled exception occured on observable"));
        }
    }
}
