using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Data
{
	public class EmployeeManagementDbContext : DbContext
	{
		public EmployeeManagementDbContext() { }
		public EmployeeManagementDbContext( DbContextOptions<EmployeeManagementDbContext> options ) : base( options ) { }
		
		
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Position> Positions{ get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Employee>()
				.HasMany(e => e.OwnedPositions)
				.WithOne(p => p.Employee);

			builder.Entity<EmployeePositions>()
				.HasKey(ep => new { ep.EmployeeId, ep.PositionId, ep.StartedFrom });

			builder.Entity<EmployeePositions>()
				.HasOne(p => p.Position)
				.WithMany();


			builder.Entity<Employee>()
				.HasData(
					new Employee
					{
						Id = Guid.Parse("a1111111-1111-3333-4444-555555555555"),
						FullName = "Ion Ionescu",
						Birthday = new DateTime(1990, 02, 10)
					},
					new Employee
					{
						Id = Guid.Parse("a1111111-2222-3333-4444-555555555555"),
						FullName = "Ana Ixulescu",
						Birthday = new DateTime(1990, 02, 10)
					},
					new Employee
					{
						Id = Guid.Parse("a1111111-3333-3333-4444-555555555555"),
						FullName = "Iox Axios",
						Birthday = new DateTime(1990, 02, 10)
					}
				);

			builder.Entity<Position>()
				.HasData(
					new Position
					{
						Id = Guid.Parse("b1111111-1111-3333-4444-555555555555"),
						Title = "Programmer",
						Department = "R&D",
						Description = "Maintain software systems",
					},
					new Position
					{
						Id = Guid.Parse("b1111111-2222-3333-4444-555555555555"),
						Title = "Talent Acquisition Manager",
						Department = "HR",
						Description = "Find right candidates for positions"
					},
					new Position
					{
						Id = Guid.Parse("b1111111-3333-3333-4444-555555555555"),
						Title = "Content Strategist",
						Department = "Marketing",
						Description = "Create new content for social media"
					}
				);

			builder.Entity<EmployeePositions>()
				.HasData(
					new EmployeePositions
					{
						EmployeeId = Guid.Parse("a1111111-1111-3333-4444-555555555555"),
						PositionId = Guid.Parse("b1111111-1111-3333-4444-555555555555"),
						Salary = 2000,
						StartedFrom = new DateTime(2019,2,1)

					},
					new EmployeePositions
					{
						EmployeeId = Guid.Parse("a1111111-2222-3333-4444-555555555555"),
						PositionId = Guid.Parse("b1111111-2222-3333-4444-555555555555"),
						Salary = 2000,
						StartedFrom = new DateTime(2017, 5, 1),
						EndedAt = new DateTime(2018,1,31)
					},
					new EmployeePositions
					{
						EmployeeId = Guid.Parse("a1111111-3333-3333-4444-555555555555"),
						PositionId = Guid.Parse("b1111111-3333-3333-4444-555555555555"),
						Salary = 2000,
						StartedFrom = new DateTime(2017, 1, 1)
					}
				);
		}
	}
}
