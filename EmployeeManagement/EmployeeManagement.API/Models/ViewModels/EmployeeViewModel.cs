using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models.ViewModels
{
	public class EmployeeViewModel
	{
		public  string Id { get; set; } = string.Empty;
		[Required]
		public string FullName { get; set; } = string.Empty;
		[Required]
		public string Birthday { get; set; } = string.Empty;
		[Required]
		public float Salary { get; set; }
		[Required]
		public string StartedFrom { get; set; } = string.Empty;
		public string? EndedAt { get; set; }
		[Required]
		public string PositionId { get; set; } = string.Empty;
	}
}
