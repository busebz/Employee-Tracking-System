using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffTrack.Data;
using StaffTrack.Models.DTOs;
using StaffTrack.Models.Entities;
using StaffTrack.Models.ViewModels;
using StaffTrack.Services;

namespace StaffTrack.Controllers
{
	public class EmployeesController : Controller
	{
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;

        }


        [HttpGet]
		public async Task<IActionResult> Index()
		{
			var employees = await _employeeService.GetAllEmployeesAsync();
			return View(employees);
		}


        [HttpGet]
		public async Task<IActionResult> EmployeeDetail(Guid Id)
		{
            var employeeDto = await _employeeService.GetEmployeeByIdAsync(Id);  

            if (employeeDto != null)
            {
                var employeeViewModel = _mapper.Map<EmployeeViewModel>(employeeDto);
                return View(employeeViewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeDto addEmployeeRequest)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployeeAsync(addEmployeeRequest);
                return RedirectToAction("Index");
            }
            return View(addEmployeeRequest);
        }


        [HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var employeeDto = await _employeeService.GetEmployeeByIdAsync(id);

			if (employeeDto != null)
			{
                var employeeViewModel = _mapper.Map<UpdateEmployeeViewModel>(employeeDto);
                return View(employeeViewModel);
			}
			return RedirectToAction("Update");
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateEmployeeDto updateEmployeeRequest)
		{
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(updateEmployeeRequest);
                return RedirectToAction("Index");
            }

            return View(updateEmployeeRequest);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id) 
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }

    }
}
