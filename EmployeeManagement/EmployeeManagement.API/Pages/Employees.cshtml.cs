using Azure.Core;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.ViewModels;
using EmployeeManagement.DAL.Data;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly ILogger<EmployeesModel> _logger;
        private readonly EmployeeManagementDbContext _context;
		public List<SelectListItem> PositionOptions { get; set; } = new();

		public CreateEmployeeViewModel CreateInput { get; set; }
		public UpdateEmployeeViewModel UpdateInput { get; set; }


		public EmployeesModel(ILogger<EmployeesModel> logger, EmployeeManagementDbContext context)
        {
            _logger = logger;
			_context = context;
        }


        public async Task OnGetAsync()
        {
			PositionOptions = await _context.Positions
			.Select(p => new SelectListItem
			{
				Value = p.Id.ToString(),
				Text = p.Title
			}).ToListAsync();
		}

		public async Task<JsonResult> OnGetEmployeesAsync()
		{
			var employees = await _context.Employees
				.Select(e => new {
					Department = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Position.Department).FirstOrDefault(),
					e.FullName,
					e.Birthday,
					EmployedFrom = e.OwnedPositions.OrderBy(op => op.StartedFrom).Select(op => op.StartedFrom).FirstOrDefault(),
					Salary = e.OwnedPositions.OrderByDescending(op => op.Salary).Select(op => op.Salary).FirstOrDefault(),
					e.Id,
				})
				.ToListAsync();

			return new JsonResult(new { data = employees });
		}

		public async Task<JsonResult> OnGetEmployeeAsync([FromQuery] Guid Id)
		{
			var employee = await _context.Employees
				.Where(e => e.Id == Id)
				.Select(e => new {
					e.Id,
					e.FullName,
					Birthday = e.Birthday.ToString("yyyy-MM-dd"),
					Salary = e.OwnedPositions.OrderByDescending(op => op.Salary).Select(op => op.Salary).FirstOrDefault(),
					EmployedFrom = e.OwnedPositions.OrderBy(op => op.StartedFrom).Select(op => op.StartedFrom).FirstOrDefault().ToString("yyyy-MM-dd"),
					EndedAt = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.EndedAt).FirstOrDefault().ToString() ?? null,
					PositionId = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.PositionId).FirstOrDefault(),
				})
				.FirstOrDefaultAsync();

			if (employee == null)
				return new JsonResult(null);

			return new JsonResult(employee);
		}

		
		public async Task<JsonResult> OnPostCreateAsync([FromBody] CreateEmployeeViewModel CreateInput)
		{
			if (!ModelState.IsValid)
				return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

			var position = await _context.Positions.FindAsync(CreateInput.PositionId);
			if (position == null)
				return new JsonResult(new { success = false, message = "Position not found" });

			var employee = new Employee
			{
				FullName = CreateInput.FullName,
				Birthday = CreateInput.Birthday,
				OwnedPositions = new List<EmployeePositions>()
			};

			var employeePosition = new EmployeePositions
			{
				EmployeeId = employee.Id,
				PositionId = position.Id,
				Salary = CreateInput.Salary,
				StartedFrom = CreateInput.StartedFrom,
				EndedAt = CreateInput.EndedAt,
				Employee = employee,
				Position = position
			};

			employee.OwnedPositions.Add(employeePosition);
			_context.Employees.Add(employee);

			await _context.SaveChangesAsync();

			return new JsonResult(new { success = true, employee.Id });
		}

		
		public async Task<JsonResult> OnPostUpdateAsync([FromBody] UpdateEmployeeViewModel UpdateInput )
		{
			if (!ModelState.IsValid)
				return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });


			var employee = await _context.Employees
			.Include(e => e.OwnedPositions)
			.FirstOrDefaultAsync(e => e.Id == UpdateInput.Id);

			if (employee == null)
				return new JsonResult(new { success = false, message = "Employee not found" });

			employee.FullName = UpdateInput.FullName;
			employee.Birthday = UpdateInput.Birthday;

			_context.Employees.Update(employee);
			await _context.SaveChangesAsync();

			return new JsonResult(new { success = true });
		}

		public async Task<JsonResult> OnPostDeleteAsync([FromBody] DeleteEmployeeRequest request)
		{
			_logger.LogInformation("Entered delete endpoint");
			var employee = await _context.Employees.FindAsync(request.Id);
			if (employee == null)
				return new JsonResult(new { success = false, message = "Employee not found" });

			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();

			return new JsonResult(new { success = true });
		}
	}

}
