using EmployeeManagement.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Configurations
{
	public static class DbConfig
	{
		public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration configuration)
		{
			return services.AddDbContext<EmployeeManagementDbContext>(optionsBuilder =>
			{
				var connectionStringName = "EmployeeManagementConnectionString";
				var conn = configuration.GetConnectionString(connectionStringName);
				if (string.IsNullOrWhiteSpace(conn))
				{
					throw new InvalidOperationException("Connection string is invalid.");
				}
				optionsBuilder.UseSqlServer(conn);

			});
		}
	}
}
