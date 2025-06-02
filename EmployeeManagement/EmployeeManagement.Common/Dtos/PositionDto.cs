namespace EmployeeManagement.Common.Dtos
{
	public class PositionDto
	{
		public required Guid Id { get; set; }
		public required string Title { get; set; }
		public required string Department { get; set; }
	}
}
