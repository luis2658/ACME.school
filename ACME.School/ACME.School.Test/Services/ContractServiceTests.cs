using ACME.School.Service.Abstract;
using ACME.School.Service.Interface;
using ACME.School.Service.Model;
using ACME.School.Service.Service;
using ACME.School.Test.Data;
using Moq;

namespace ACME.School.Test.Services
{
    [TestFixture]
    public class ContractServiceTests
    {
        private ContractService _contractService;
        Mock<IPayment<IPaymentMethod>> paymentService;

        [SetUp] 
        public void SetUp() 
        {
            Mock<IStudentService> studentService = new Mock<IStudentService>();

            studentService.Setup(x => x.GetById(It.IsAny<int>())).Returns(MockData.Student);
            studentService.Setup(x => x.Update(It.IsAny<Student>())).Returns(true);

            Mock<ICourseService> courseService = new Mock<ICourseService>();

            courseService.Setup(x => x.GetById(It.IsAny<int>())).Returns(MockData.Course);
            courseService.Setup(x => x.Update(It.IsAny<Course>())).Returns(true);

            paymentService = new Mock<IPayment<IPaymentMethod>>();

            paymentService.Setup(x => x.MakePayment(It.IsAny<IPaymentMethod>())).ReturnsAsync(true);

            _contractService = new ContractService(studentService.Object, courseService.Object, paymentService.Object);
        }

        [Test]
        public async Task ContractSuccess()
        {
            paymentService.Setup(x => x.MakePayment(It.IsAny<IPaymentMethod>())).ReturnsAsync(true);

            var result = await _contractService.ContractCourses(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IPaymentMethod>());

            Assert.IsNotNull(result.Equals(true));
        }

        [Test]
        public async Task ContractFail()
        {
            paymentService.Setup(x => x.MakePayment(It.IsAny<IPaymentMethod>())).ReturnsAsync(false);

            var result = await _contractService.ContractCourses(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IPaymentMethod>());

            Assert.IsNotNull(result.Equals(false));
        }
    }
}
