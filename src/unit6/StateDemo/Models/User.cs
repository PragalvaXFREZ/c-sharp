using System.ComponentModel.DataAnnotations;

namespace StateDemo.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Range(1, 120)]
    public int Age { get; set; }
}
