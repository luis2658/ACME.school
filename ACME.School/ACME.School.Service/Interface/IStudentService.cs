using ACME.School.Service.Model;

namespace ACME.School.Service.Interface
{
    public interface IStudentService
    {
        IEnumerable<Student> GetByCourseDateRange(DateTime Start, DateTime End);
        int Register(Student student);
        Student GetById(int id);
        bool Update(Student student);
    }
}