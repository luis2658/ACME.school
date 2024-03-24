using ACME.School.Service.Abstract;
using ACME.School.Service.Interface;
using ACME.School.Service.Model;

namespace ACME.School.Service.Service
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public int Register(Course course)
        {
            return _courseRepository.Add(course);
        }

        public Course GetById(int id) 
        {
            return _courseRepository.GetById(id);
        }

        public bool Update(Course course) 
        {
            return _courseRepository.Update(course);
        }
    }
}
