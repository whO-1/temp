using EmployeeManagement.Domain.Base;
using EmployeeManagement.Domain.IEntityInterfaces;

namespace EmployeeManagement.Domain.Entities
{
	public class Employee : BaseEntity, IEntity
	{
		public required string FullName { get; set; }
		public required DateTime Birthday { get; set; }
		public ICollection<EmployeePositions>  OwnedPositions{ get; set; }
	}
}
