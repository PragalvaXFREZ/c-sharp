namespace EntityFrameworkDatabaseFirst
{
 class Program
 {
 static void Main(string[] args)
 {
 Console.WriteLine("Hello World!");
 }
 }

 public class StudentDB
 {
 public void DeleteStudent(int id)
 {
var stu=db.TbStudents.Where(a=>a.Id == id).FirstOrDefault();
db.TbStudents.Remove(stu);
db.SaveChanges();
}
 public void UpdateStudent(string name, string address, string gender,decimal salary, int id)
 {
 var stu = db.TbStudents.Where(a => a.Id == 2).FirstOrDefault();
 stu.Name = name;
 stu.Address = address;
 stu.Gender = gender;
st.Salary = salary;
 db.SaveChanges();
}
 public List< TbStudent> LoadStudent()
 {

 List<TbStudent> students = db.TbStudents.ToList();
 return students;
 }
 public void SaveStudent(string name, string address, string gender, decimal salary)
 {
 DbMydatabaseUnit5Context db = new DbMydatabaseUnit5Context();
 TbStudent st = new TbStudent();
 st.Name = name;
 st.Address = address;
 st.Gender = gender;
 st.Salary = salary;
 db.TbStudents.Add(st);
 db.SaveChanges();
}
 }
} 