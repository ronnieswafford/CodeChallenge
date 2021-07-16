using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace VerikaiCodeChallenge
{
    class SaveUnencryptedFile
    {
        public static void SaveFile(DataTable dt)
        {
            Console.WriteLine("Writing File ");
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            StreamWriter sw = new StreamWriter(directory + @"\unencrypted.tsv");
            string value = "";

            foreach(DataColumn dc in dt.Columns)
            {
                value += string.Format("{0}\t", dc.ColumnName.ToString());
            }
            sw.WriteLine(value);

            foreach(DataRow r in dt.Rows)
            {
                Console.Write("*");
                value = "";
                foreach(DataColumn c in dt.Columns)
                {
                    value += string.Format("{0}\t", r[c.ColumnName].ToString());
                }
                sw.WriteLine(value);
            }
            sw.Dispose();
            Console.WriteLine("Finished Writing File");
        }
    }
}
