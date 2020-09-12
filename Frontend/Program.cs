
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using LoggingComponent;

namespace Frontend
{
	public class Program
	{
		static ILogger _log => LoggingComponent.GetLogInstance.GetLoggingInstance("CodeTest");

		public static int Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			try
			{
				_log.LogInformation("Starting web host");
				host.Run();
				return 0;
			}
			catch (Exception ex)
			{
				_log.LogCritical(ex, "Host terminated unexpectedly");
				return 1;
			}
			finally
			{
				_log.LogInformation("Program closed");
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigurehostLogging()
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
