
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggingComponent
{
	public static class GetLogInstance
	{
		static ILoggerFactory _loggerFactory = new LoggerFactory().AddSerilog();
		public static Microsoft.Extensions.Logging.ILogger GetLoggingInstance(string loggerName)
		{
			return _loggerFactory.CreateLogger(loggerName);
		}
	}
}