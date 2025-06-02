

namespace EmployeeManagement.Common.Dtos
{
	public class EmployeeDto
	{
		public required string Id { get; set; }
		public required string FullName { get; set; }
		public required string Birthday { get; set; }
		public required string CurrentPositionTitle { get; set; }
		public required string CurrentPositionId { get; set; }
		public required float CurrentSalary { get; set; }
		public required string EmployedFrom { get; set; }
		public required string Department { get; set; }
	}
}
