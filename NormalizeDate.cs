using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerikaiCodeChallenge
{
    class NormalizeDate
    {
        public static string DOBShort(string dob)
        {
            string processedDOB = string.Empty;
            try
            {
                processedDOB = Convert.ToDateTime(dob).ToShortDateString();
            }
            catch
            {
                processedDOB = "dob processing error";
            }
            
            return processedDOB;
        }
    }
}
