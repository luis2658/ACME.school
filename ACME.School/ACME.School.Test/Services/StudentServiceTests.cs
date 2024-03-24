using ACME.School.Service.Abstract;
using ACME.School.Service.Interface;
using ACME.School.Service.Model;
using ACME.School.Service.Service;
using ACME.School.Test.Data;
using Moq;
using System.Linq.Expressions;

namespace ACME.School.Test.Services
{
    [TestFixture]
    public class StudentServiceTests
    {
        private StudentService _studentService;

        [SetUp]
        public void Setup()
        {
            Mock<IRepository<Course>> _courseRepository = new Mock<IRepository<Course>>();

            _courseRepository.Setup(x => x.GetAll()).Returns(MockData.Courses());
            _courseRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(MockData.Course());
            _courseRepository.Setup(x => x.Add(It.IsAny<Course>())).Returns(1);
            _courseRepository.Setup(x => x.Update(It.IsAny<Course>())).Returns(true);
            _courseRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Course, bool>>>()))
                .Returns(MockData.Courses());

            Mock<IRepository<Student>> _studentRepository = new Mock<IRepository<Student>>();

            _studentRepository.Setup(x => x.GetAll()).Returns(MockData.Students());
            _studentRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(MockData.Student());
            _studentRepository.Setup(x => x.Add(It.IsAny<Student>())).Returns(1);
            _studentRepository.Setup(x => x.Update(It.IsAny<Student>())).Returns(true);
            _studentRepository.Setup(x => x.Find(It.IsAny<Expression<Func<Student, bool>>>()))
                .Returns(MockData.Students());

            _studentService = new StudentService(_studentRepository.Object, _courseRepository.Object);
        }

        [Test]
        public void Registration()
        {
            var student = MockData.Student();

            var result = _studentService.Register(student);

            Assert.That(result.Equals(1));
        }

        [Test]
        public void RegistrationFail()
        {
            var student = MockData.Student();
            student.BirthDate = DateTime.Now.AddYears(-10);

            var result = _studentService.Register(student);

            Assert.That(result.Equals(0));
        }

        [Test]
        public void GetCourse()
        {
            var student = MockData.Student();

            var result = _studentService.GetById(student.Id);

            Assert.That(result.Id.Equals(student.Id));
            Assert.That(result.Name.Equals(student.Name));
            Assert.That(result.SurName.Equals(student.SurName));
            Assert.That(result.BirthDate.Equals(student.BirthDate));
        }

        [Test]
        public void UpdateCourse()
        {
            var student = MockData.Student();

            var result = _studentService.Update(student);

            Assert.That(result.Equals(true));
        }

        [Test]
        public void GetListCourseByDateRange()
        {
            var list = MockData.Students();

            var course = MockData.Course();

            var result = _studentService.GetByCourseDateRange(course.StartDate, course.EndDate);

            Assert.That(result is not null);
            Assert.That(result.Count().Equals(list.Count));
        }

    }
}
