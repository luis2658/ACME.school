using ACME.School.Service.Model;

namespace ACME.School.Service.Interface
{
    public interface ICourseService
    {
        int Register(Course course);
        Course GetById(int id); 
        bool Update(Course course);
    }
}