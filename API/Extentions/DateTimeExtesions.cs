using System;

namespace API.Extentions
{
    public static class DateTimeExtesions
    {
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.UtcNow;

            var age = today.Year - dob.Year;

            if (dob > today.AddYears(-age)) age--;

            return age;
        }
    }
}
