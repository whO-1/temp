using EmployeeManagement.Common.Dtos;

namespace EmployeeManagement.BLL
{
	public interface IEmployeeService
	{
		Task<EmployeeDto?> GetEmployeeAsync(Guid Id);
		Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
		void CreateEmployeeAsync();
		void EditEmployeeAsync();
		Task<bool> DeleteEmployeeAsync(Guid Id);


	}
}
