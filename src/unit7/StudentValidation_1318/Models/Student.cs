using System.ComponentModel.DataAnnotations;

namespace StudentValidation_1318.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone must be exactly 10 digits")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(16, 60, ErrorMessage = "Age must be between 16 and 60")]
        public int? Age { get; set; }
    }
}
