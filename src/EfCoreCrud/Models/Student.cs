using System.ComponentModel.DataAnnotations;

namespace EfCoreCrud.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string RollNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Course { get; set; } = string.Empty;
}
