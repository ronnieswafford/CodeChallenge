using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerikaiCodeChallenge
{
    class AgeFromDOB
    {
        public static string Age(string dob)
        {
            string age = string.Empty;
            try
            {
                DateTime birthDay = Convert.ToDateTime(dob);
                if (birthDay.Year > DateTime.Now.Year)
                {
                    age = "dob is in the future. Time traveler?";
                }
                else
                {
                    age = (DateTime.Now.Year - birthDay.Year).ToString();
                } 
            }
            catch
            {
                age = "conversion error";
            }
            return age;
        }
    }
}
