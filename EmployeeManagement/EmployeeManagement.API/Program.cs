using EmployeeManagement.API.Configurations;
using EmployeeManagement.DAL.Data;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var logger = LogManager.Setup()
	.LoadConfigurationFromAppSettings()
	.GetCurrentClassLogger();

try
{
	logger.Info("Starting up the application");

	var builder = WebApplication.CreateBuilder(args);

	builder.Logging.ClearProviders();
	builder.Logging.SetMinimumLevel(LogLevel.Trace);
	builder.Host.UseNLog();

	builder.Services.AddDbConfig(builder.Configuration);

	builder.Services.AddRazorPages();

	var app = builder.Build();

	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Error");
		app.UseHsts();
	}

	app.UseHttpsRedirection();
	app.UseStaticFiles();

	app.UseRouting();

	app.MapRazorPages();


	using (var scope = app.Services.CreateScope())
	{
		var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeManagementDbContext>();
		dbContext.Database.Migrate();
	}

	app.Run();
}
catch(Exception ex)
{
	logger.Error(ex, "Application stopped due to an exception");
	throw;
}
finally
{
	LogManager.Shutdown();
}




