using Azure.Core;
using EmployeeManagement.Common.Dtos;
using EmployeeManagement.DAL.Data;
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace EmployeeManagement.BLL
{
	public class EmployeeService : IEmployeeService
	{
		private readonly ILogger<EmployeeService> _logger;
		private readonly EmployeeManagementDbContext _context;

		public EmployeeService(ILogger<EmployeeService> logger, EmployeeManagementDbContext context)
		{
			_logger = logger;
			_context = context;
		}


		public async Task<EmployeeDto?> GetEmployeeAsync(Guid Id)
		{
			var employee = await _context.Employees
				.Where(e => e.Id == Id)
				.Select(e => new EmployeeDto {
					Id = e.Id.ToString(),
					FullName = e.FullName,
					Birthday = e.Birthday.ToString(),
					CurrentSalary = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Salary).FirstOrDefault(),
					CurrentPositionTitle = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Position.Title).FirstOrDefault() ?? string.Empty,
					CurrentPositionId = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Position.Id).FirstOrDefault().ToString() ,
					Department = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Position.Department).FirstOrDefault() ?? string.Empty,
					EmployedFrom = e.OwnedPositions.OrderBy(op => op.StartedFrom).Select(op => op.StartedFrom).FirstOrDefault().ToString(),
				})
				.FirstOrDefaultAsync();
			if(employee is null)
			{
				throw new KeyNotFoundException("User id not found.");
			}

			return employee;
		}

		public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
		{
			List<EmployeeDto> employees;

			employees = await _context.Employees
				.Select(e => new EmployeeDto {
					Id = e.Id,
					FullName = e.FullName,
					Birthday = e.Birthday,
					CurrentSalary = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Salary).FirstOrDefault(),
					CurrentPosition = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Position.Title).FirstOrDefault() ?? string.Empty,
					Department = e.OwnedPositions.OrderByDescending(op => op.StartedFrom).Select(op => op.Position.Department).FirstOrDefault() ?? string.Empty,
					EmployedFrom = e.OwnedPositions.OrderBy(op => op.StartedFrom).Select(op => op.StartedFrom).FirstOrDefault().ToString(),
				})
				.ToListAsync();

			if (employees is null)
				employees = new List<EmployeeDto>();

			return employees;
		}
		public void CreateEmployeeAsync()
		{

		}

		public void EditEmployeeAsync()
		{

		}
		public async Task<bool> DeleteEmployeeAsync(Guid Id)
		{
			var employee = await _context.Employees.FindAsync(Id);
			if (employee == null)
				return false;

			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();
			return true;
		}

		
	}
}
