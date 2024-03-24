namespace ACME.School.Service.Util
{
    public static class DateTimeHelper
    {
        public static bool IsAdult(this DateTime birthDate)
        {
            var MinDate = DateTime.Now.AddYears(-18);            

            return birthDate >= MinDate;
        }
    }
}
