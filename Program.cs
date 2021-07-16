using System;
using System.Data;
using System.Text.RegularExpressions;

namespace VerikaiCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            FileDownload.GetFile("http://devchallenge.verikai.com/", "data.tsv");
            Console.WriteLine("Success Downloading File");
            DataTable dt = FileToDataTable.GetDataTable("data.tsv");
            ProcessFile(dt);
            Console.ReadLine();
        }

        static void ProcessFile(DataTable dt)
        {
            Console.WriteLine("Processing File");
            dt.Columns.Add("age");
            dt.Columns.Add("cost");
            foreach(DataRow r in dt.Rows)
            {
                r["gender"] = r["gender"].ToString().Substring(0, 1);
                r["dob"] = NormalizeDate.DOBShort(r["dob"].ToString());
                if (r["phone"].ToString().Contains("+"))
                {
                    r["phone"] = r["phone"].ToString().Remove(0, 2);
                }
                r["phone"] = Regex.Replace(r["phone"].ToString(), "[^0-9]", "");
                r["age"] = AgeFromDOB.Age(r["dob"].ToString());
                r["cost"] = CalculateCost.Cost(r["zip"].ToString().Substring(0, 3));
                Console.WriteLine("Finished File Processing. Saving Unencrypted File");
            }
            SaveUnencryptedFile.SaveFile(dt);
        }
    }
}
