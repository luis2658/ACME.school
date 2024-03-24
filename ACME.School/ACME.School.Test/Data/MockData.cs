using ACME.School.Service.Model;

namespace ACME.School.Test.Data
{
    public static class MockData
    {
        public static DateTime FakeBirhDate()
        {
            Random rnd = new Random();

            return new DateTime(rnd.Next(1980, 2000), rnd.Next(1, 12), rnd.Next(1, 30));
        }

        public static Student Student()
        {
            return new Student { 
                Id = 5, 
                Name = "Luis", 
                SurName = "Atencio", 
                BirthDate = new DateTime(2000, 9, 15),
            };
        }


        public static List<Student> Students()
        {
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Luis", SurName = "Atencio", BirthDate = FakeBirhDate() },
                new Student { Id = 2, Name = "Jpse", SurName = "Perez", BirthDate = FakeBirhDate() },
                new Student { Id = 3, Name = "Jhon", SurName = "Smith", BirthDate = FakeBirhDate() },
                new Student { Id = 4, Name = "Rays", SurName = "Koolit", BirthDate = FakeBirhDate() }
            };

            return students;
        }

        public static Course Course()
        {
            return new Course
            {
                Id = 5,
                Name = "Art",
                RegistrationFee = new decimal(200.20),
                StartDate = new DateTime(2024, 9, 15),
                EndDate = new DateTime(2024, 8, 15)
            };
        }

        public static List<Course> Courses() 
        {
            var courses = new List<Course>
            {
                new Course { Id = 1, Name = "Math", RegistrationFee = new decimal(200.20), StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(45) },
                new Course { Id = 2, Name = "Earth", RegistrationFee = new decimal(200.20), StartDate = DateTime.Now.AddDays(-30), EndDate = DateTime.Now.AddDays(15) },
                new Course { Id = 3, Name = "Marcial Arts", RegistrationFee = new decimal(200.20), StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(46) },
                new Course { Id = 4, Name = "Physics", RegistrationFee = new decimal(200.20), StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(30) }
            };

            return courses;
        }

    }
}
