using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaffTrack.Data;
using StaffTrack.Models.DTOs;
using StaffTrack.Models.Entities;
using StaffTrack.Models.ViewModels;
using StaffTrack.Repositories;

namespace StaffTrack.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return null;
            return _mapper.Map<EmployeeDto>(employee);
        }
        public async Task AddEmployeeAsync(AddEmployeeDto addEmployeeRequest)
        {
            var employee = _mapper.Map<Employee>(addEmployeeRequest);
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeRequest)
        {
            var employee = await _employeeRepository.GetByIdAsync(updateEmployeeRequest.Id);

            if (employee != null)
            {
                _mapper.Map(updateEmployeeRequest, employee);
                await _employeeRepository.UpdateAsync(employee);
            }
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

    }
}
