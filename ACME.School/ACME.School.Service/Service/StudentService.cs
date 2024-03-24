using ACME.School.Service.Abstract;
using ACME.School.Service.Interface;
using ACME.School.Service.Model;
using ACME.School.Service.Util;

namespace ACME.School.Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Course> _courseRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public int Register(Student student)
        {
            if (student.BirthDate.IsAdult())
            {
                return 0;
            }

            return _studentRepository.Add(student);            
        }
        public Student GetById(int id) 
        {
            return _studentRepository.GetById(id);
        }

        public bool Update(Student student) 
        {
            return _studentRepository.Update(student);
        }

        public IEnumerable<Student> GetByCourseDateRange(DateTime Start, DateTime End)
        {
            var courses = _courseRepository.Find(x => x.StartDate > Start && x.EndDate < End);

            var StudentIds = courses.SelectMany(x => x.Students.Select(x => x.Id)).Distinct().ToList();

            return _studentRepository.Find(x => StudentIds.Contains(x.Id));
        }
    }
}
