using ACME.School.Service.Abstract;
using ACME.School.Service.Interface;

namespace ACME.School.Service.Service
{
    public class ContractService
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly IPayment<IPaymentMethod> _paymentService;

        public ContractService(IStudentService studentService, ICourseService courseService, IPayment<IPaymentMethod>? paymentService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _paymentService = paymentService;
        }

        public async Task<bool> ContractCourses(int studentId, int courseId, IPaymentMethod paymentInfo)
        {
            var student = _studentService.GetById(studentId);

            var course = _courseService.GetById(courseId);

            var response = await _paymentService.MakePayment(paymentInfo);

            if (!response)
            {
                return false;
            }

            student.Courses.Add(course);
            course.Students.Add(student);

            _studentService.Update(student);
            _courseService.Update(course);

            return true;
        }
    }
}
