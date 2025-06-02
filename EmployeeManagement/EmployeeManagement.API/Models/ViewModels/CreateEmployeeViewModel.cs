namespace EmployeeManagement.API.Models.ViewModels
{
	public class CreateEmployeeViewModel
	{
		public required string FullName { get; set; }
		public required DateTime Birthday { get; set; }
		public required float Salary { get; set; }
		public required DateTime StartedFrom { get; set; }
		public DateTime? EndedAt { get; set; }
		public required Guid PositionId { get; set; }
	}
}
