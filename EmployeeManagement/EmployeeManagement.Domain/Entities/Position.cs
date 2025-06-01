using EmployeeManagement.Domain.Base;
using EmployeeManagement.Domain.IEntityInterfaces;

namespace EmployeeManagement.Domain.Entities
{
	public class Position: BaseEntity, IEntity
	{
		public required string Title { get; set; }
		public required string Description { get; set; }
		public required string Department { get; set; }
	}
}
