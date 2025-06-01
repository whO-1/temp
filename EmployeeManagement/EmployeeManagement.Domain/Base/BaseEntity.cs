using EmployeeManagement.Domain.IEntityInterfaces;

namespace EmployeeManagement.Domain.Base
{
	public class BaseEntity : IEntity
	{
		public Guid Id { get; set; }
	}
}
