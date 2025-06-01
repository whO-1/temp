namespace EmployeeManagement.Domain.Entities
{
	public class EmployeePositions
	{
		public required float Salary { get; set; }
		public required DateTime StartedFrom { get; set; }
		public DateTime? EndedAt { get; set; } = null;

		public Guid EmployeeId { get; set; }	
		public Guid PositionId { get; set; }
		public Employee Employee { get; set; } = null!;
		public Position Position { get; set; } = null!;
		
	}
}
