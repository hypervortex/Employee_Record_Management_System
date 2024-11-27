using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Record_Management_System.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int EmployeeId { get; set; }

        [Required, MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required, Phone]
        public string? MobileNumber { get; set; }

        [Phone]
        public string? AlternateNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AnniversaryDate { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(10)]
        public string? Pincode { get; set; }

        [MaxLength(10)]
        public string? BloodGroup { get; set; }

        [MaxLength(100)]
        public string? EmergencyContactName { get; set; }

        [Phone]
        public string? EmergencyNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfJoining { get; set; }
    }
}
