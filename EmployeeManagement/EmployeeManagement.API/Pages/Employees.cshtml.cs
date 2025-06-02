using EmployeeManagement.API.Models.Requests;
using EmployeeManagement.API.Models.ViewModels;
using EmployeeManagement.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace EmployeeManagement.API.Pages
{
	public class EmployeesModel : PageModel
    {
        private readonly ILogger<EmployeesModel> _logger;
		private readonly EmployeeService _employeeService;
		private readonly PositionService _positionService;
		public List<SelectListItem> PositionOptions { get; set; } = new();

		public EmployeesModel(ILogger<EmployeesModel> logger, EmployeeService employeeService, PositionService positionService)
        {
            _logger = logger;
			_employeeService = employeeService;
			_positionService = positionService;
        }


        public async Task OnGetAsync()
        {
			var positions = await _positionService.GetPositionsAsync();
			PositionOptions = positions.Select(p =>  new SelectListItem
			{
				Value = p.Id.ToString(),
				Text = p.Title,
			}).ToList();
		}

		public async Task<JsonResult> OnGetEmployeesAsync()
		{
			var employees = await _employeeService.GetEmployeesAsync();

			return new JsonResult(new { data = employees });
		}

		public async Task<JsonResult> OnGetEmployeeAsync([FromQuery] Guid Id)
		{
			var employee = await _employeeService.GetEmployeeAsync(Id);

			if (employee == null)
				return new JsonResult(null);

			return new JsonResult(employee);
		}

		
		public async Task<JsonResult> OnPostCreateAsync([FromBody] EmployeeViewModel model )
		{
			if (!ModelState.IsValid)
				return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

			

			return new JsonResult(new { success = true });
		}

		
		public async Task<JsonResult> OnPostUpdateAsync()
		{
			if (!ModelState.IsValid)
				return new JsonResult(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });



			return new JsonResult(new { success = true });
		}

		public async Task<JsonResult> OnPostDeleteAsync([FromBody] DeleteEmployeeRequest request)
		{
			_logger.LogInformation("Entered delete endpoint");
			
			var result = await _employeeService.DeleteEmployeeAsync(request.Id);

			return new JsonResult(new { success = result });
		}

		public async Task<PartialViewResult> OnGetLoadEmployeeModalAsync(Guid? id)
		{
			EmployeeViewModel model;

			if (id.HasValue)
			{
				var employee = await  _employeeService.GetEmployeeAsync(id.Value);

				if (employee == null)
				{
					model = new EmployeeViewModel();
				}
				else
				{
					model = new EmployeeViewModel
					{
						Id = employee.Id,
						FullName = employee.FullName,
						Birthday = employee.Birthday,
						Salary = employee.CurrentSalary,
						StartedFrom = employee.EmployedFrom,
						PositionId = employee.CurrentPositionId,
					};
				}
			}
			else
			{
				model = new EmployeeViewModel();
			}

			var positions = await _positionService.GetPositionsAsync();

			var positionOptions = positions.Select(p => new SelectListItem {
				Value = p.Id.ToString(), 
				Text = p.Title 
			});

			var viewData = new ViewDataDictionary<EmployeeViewModel>(metadataProvider: new EmptyModelMetadataProvider(),modelState: ModelState)
			{
				Model = model 
			};

			viewData["PositionOptions"] = positionOptions;
			viewData["Title"] = id.HasValue ? "Update" : "Create";

			return new PartialViewResult
			{
				ViewName = "_ModalFormPartial",
				ViewData = viewData
			};

		}
	}

}
