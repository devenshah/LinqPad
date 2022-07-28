<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Hosting</Namespace>
  <Namespace>Microsoft.AspNetCore.Builder</Namespace>
  <Namespace>Microsoft.AspNetCore.Http</Namespace>
  <Namespace>Microsoft.Extensions.Primitives</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>Microsoft.AspNetCore.Html</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	var host = Host.CreateDefaultBuilder()
		.ConfigureWebHostDefaults(webBuilder =>webBuilder.UseStartup<Startup>())
		.Build();
	host.Run();
}

public class MyController: Controller
{
	public IActionResult Index()
	{
		//A GET or POST to https://localhost:5001/my/index both works
		//unless an attribute is put to restrict verb
		return Ok("Hello crazy world");
	}	
}

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddMvc(options => options.EnableEndpointRouting = false);
	}
	public void Configure(IApplicationBuilder app)
	{
		app.Use(async (context, next) =>
		{
			//if (!context.Response.Headers.ContainsKey("X-Permitted-Cross-Domain-Policies"))
			{
				context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", new StringValues("none"));
			}
			await next();
		});
		app.Use(async (context, next) =>
		{
			var originBody = context.Response.Body;
			try
			{
				var watch = Stopwatch.StartNew();
				
				var memStream = new MemoryStream();
				context.Response.Body = memStream;

				await next(context).ConfigureAwait(false);

				memStream.Position = 0;
				var responseBody = new StreamReader(memStream).ReadToEnd();

				//Custom logic to modify response
				responseBody += $"{Environment.NewLine}Request was completed in {watch.ElapsedMilliseconds}ms";

				var memoryStreamModified = new MemoryStream();
				var sw = new StreamWriter(memoryStreamModified);
				sw.Write(responseBody);
				sw.Flush();
				memoryStreamModified.Position = 0;

				await memoryStreamModified.CopyToAsync(originBody).ConfigureAwait(false);
			}
			finally
			{
				context.Response.Body = originBody;
			}
		});
		app.Use(async (context, next) =>
		{
			if (context.Request.Path == "/")
			{
				await context.Response.WriteAsync("Hello World!");
				return;
			}

			await next();
		});
		app.UseMvc(routes =>
		{
			routes.MapRoute(
				name: "default",
				template: "{controller=Home}/{action=Index}/{id?}");
		});
	}
}