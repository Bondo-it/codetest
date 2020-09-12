
using System;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

namespace LoggingComponent
{

	public class TypedLoggingComponent<T> : Microsoft.Extensions.Logging.ILogger<T>
	{
		Microsoft.Extensions.Logging.ILogger _logger;

		public TypedLoggingComponent(Serilog.ILogger logger)
		{
			using (var logfactory = new SerilogLoggerFactory(logger))
			{
				_logger = logfactory.CreateLogger(typeof(T).FullName);
			}
		}

		public IDisposable BeginScope<TState>(TState state) => _logger.BeginScope<TState>(state);

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) =>
			_logger.Log<TState>(logLevel, eventId, state, exception, formatter);

		IDisposable Microsoft.Extensions.Logging.ILogger.BeginScope<TState>(TState state) =>
			_logger.BeginScope<TState>(state);

		bool Microsoft.Extensions.Logging.ILogger.IsEnabled(LogLevel logLevel) =>
			_logger.IsEnabled(logLevel);

		void Microsoft.Extensions.Logging.ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) =>
			_logger.Log<TState>(logLevel, eventId, state, exception, formatter);
	}
}
