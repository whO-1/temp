

using EmployeeManagement.Common.Dtos;
using EmployeeManagement.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.BLL
{
	public class PositionService : IPositionService
	{
		private readonly ILogger<EmployeeService> _logger;
		private readonly EmployeeManagementDbContext _context;

		public PositionService(ILogger<EmployeeService> logger, EmployeeManagementDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IEnumerable<PositionDto>> GetPositionsAsync()
		{
			List<PositionDto> positions;
			positions = await _context.Positions.Select(p => new PositionDto
			{
				Id = p.Id,
				Title = p.Title,
				Department = p.Department,
			}).ToListAsync();

			if(positions is null)
				positions = new List<PositionDto>();

			return positions;
		}
	}
}
