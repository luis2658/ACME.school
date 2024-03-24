namespace ACME.School.Service.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Course> Courses { get;} = new List<Course>();
    }
}
