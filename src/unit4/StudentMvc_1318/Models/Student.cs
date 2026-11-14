namespace StudentMvc_1318.Models
{
    // Model: plain data describing one student record.
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
