using EmployeeManagement.Common.Dtos;

namespace EmployeeManagement.BLL
{
	public interface IPositionService
	{
		Task<IEnumerable<PositionDto>> GetPositionsAsync();

	}
}
