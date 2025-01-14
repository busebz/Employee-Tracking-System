using StaffTrack.Models.DTOs;
using StaffTrack.Models.Entities;
using StaffTrack.Models.ViewModels;

namespace StaffTrack.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task AddEmployeeAsync(AddEmployeeDto addEmployeeRequest);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeRequest);
        Task DeleteEmployeeAsync(Guid id);
    }
}
