namespace StaffTrack.Models.DTOs
{
    public class AddEmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}
