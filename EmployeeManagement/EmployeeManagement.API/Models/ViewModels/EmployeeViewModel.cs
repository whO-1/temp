using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models.ViewModels
{
	public class EmployeeViewModel
	{
		public  Guid Id { get; set; }
		[Required]
		public string FullName { get; set; }
		[Required]
		public DateTime Birthday { get; set; }
		[Required]
		public float Salary { get; set; }
		[Required]
		public DateTime StartedFrom { get; set; }
		public DateTime? EndedAt { get; set; }
		[Required]
		public Guid PositionId { get; set; }
	}
}
