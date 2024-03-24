namespace ACME.School.Service.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
