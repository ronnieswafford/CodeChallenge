using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace VerikaiCodeChallenge
{
    class FileToDataTable
    {
        static IEnumerable<string> ReadAsLines(string filename)
        {
            using (var reader = new StreamReader(filename))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
        public static DataTable GetDataTable(string fileName)
        {
            var reader = ReadAsLines(fileName);
            DataTable dt = new DataTable();

            var headers = reader.First().Split('\t');
            foreach (var header in headers)
                dt.Columns.Add(header);

            var records = reader.Skip(1);
            foreach (var record in records)
                dt.Rows.Add(record.Split('\t'));

            return dt;
        }

        public static DataTable GetDataTableFromCSV(string fileName)
        {
            var reader = ReadAsLines(fileName);
            DataTable dt = new DataTable();

            var headers = reader.First().Split(',');
            foreach (var header in headers)
                dt.Columns.Add(header);

            var records = reader.Skip(1);
            foreach (var record in records)
                dt.Rows.Add(record.Split(','));

            return dt;
        }
    }
}
