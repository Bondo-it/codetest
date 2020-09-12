using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggingComponent
{
	public static class AddLogger
	{
		public static void ConfigureLogging(this Microsoft.Extensions.Logging.ILoggingBuilder logging)
		{
			logging.ClearProviders();
			logging.AddSerilog();
		}

		public static IWebHostBuilder ConfigureWebhostLogging(this IWebHostBuilder webHostBuilder) => webHostBuilder.UseSerilog();
		public static IHostBuilder ConfigurehostLogging(this IHostBuilder hostBuilder) => hostBuilder.UseSerilog();
	}
}