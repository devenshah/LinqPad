<Query Kind="Program">
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.Extensions.Logging</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

// You can reference the ASP.NET Core Framework (if installed) - just press F4 and tick the checkbox.

Task Main()
{
	// This query uses soft cancellation to shut down the server - see query://..\Runtime_Services\Soft_cancellation
	var serverTask = CreateHostBuilder().Build().RunAsync (QueryCancelToken);
	new WebClient().DownloadString ("http://localhost:5000/weatherforecast").Dump ("Test request");
	return serverTask;
}

public static IHostBuilder CreateHostBuilder() =>
	Host.CreateDefaultBuilder ()
		.ConfigureWebHostDefaults (webBuilder =>
		{
			webBuilder.UseStartup<Startup> ();
		});

public class Startup
{
	public Startup (IConfiguration configuration) => Configuration = configuration;

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices (IServiceCollection services) => services.AddControllers ();

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
	{
		app.UseRouting();
		app.UseEndpoints (endpoints => endpoints.MapControllers ());
	}
}

namespace Controllers
{
	[ApiController]
	[Route ("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController (ILogger<WeatherForecastController> logger) => _logger = logger;

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var rng = new Random ();
			return Enumerable.Range (1, 5).Select (index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays (index),
				TemperatureC = rng.Next (-20, 55),
				Summary = Summaries [rng.Next (Summaries.Length)]
			})
			.ToArray ();
		}
	}
}

public class WeatherForecast
{
	public DateTime Date { get; set; }
	public int TemperatureC { get; set; }
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
	public string Summary { get; set; }
}