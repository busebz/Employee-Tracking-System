using System.ComponentModel.DataAnnotations;

namespace StaffTrack.Models.ViewModels
{
    public class UpdateEmployeeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public long Salary { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]

        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Department is required.")]

        public string Department { get; set; }
    }
}
