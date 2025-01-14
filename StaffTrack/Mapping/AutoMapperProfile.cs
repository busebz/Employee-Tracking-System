using AutoMapper;
using StaffTrack.Models.DTOs;
using StaffTrack.Models.Entities;
using StaffTrack.Models.ViewModels;

namespace StaffTrack.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Employee, UpdateEmployeeViewModel>(); 
            CreateMap<EmployeeDto, UpdateEmployeeViewModel>();  
            CreateMap<EmployeeDto, EmployeeViewModel>(); 
        }
    }

}
