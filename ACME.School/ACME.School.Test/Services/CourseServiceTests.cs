using ACME.School.Service.Abstract;
using ACME.School.Service.Model;
using ACME.School.Service.Service;
using ACME.School.Test.Data;
using Moq;

namespace ACME.School.Test.Services
{
    [TestFixture]
    public class CourseServiceTests
    {
        private CourseService _courseService;        

        [SetUp] 
        public void SetUp() 
        {
            Mock<IRepository<Course>> _courseRepository = new Mock<IRepository<Course>>();

            _courseRepository.Setup(x => x.GetAll()).Returns(MockData.Courses());
            _courseRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(MockData.Course());
            _courseRepository.Setup(x => x.Add(It.IsAny<Course>())).Returns(1);
            _courseRepository.Setup(x => x.Update(It.IsAny<Course>())).Returns(true);

            _courseService = new CourseService( _courseRepository.Object);
        }

        [Test]
        public void Registration() 
        {
            var course = MockData.Course();

            var result = _courseService.Register(course);

            Assert.That(result.Equals(1));
        }

        [Test]
        public void GetCourse() 
        {
            var course = MockData.Course();

            var result = _courseService.GetById(course.Id);

            Assert.That(result.Id.Equals(course.Id));
            Assert.That(result.Name.Equals(course.Name));
            Assert.That(result.StartDate.Equals(course.StartDate));
            Assert.That(result.EndDate.Equals(course.EndDate));
        }

        [Test]
        public void UpdateCourse() 
        {
            var course = MockData.Course();

            var result = _courseService.Update(course);

            Assert.That(result.Equals(true));
        }
    }
}
