using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace VerikaiCodeChallenge
{
    class CalculateCost
    {
        public static string Cost(string zip3)
        {
            string cost = string.Empty;
            string areaClass = string.Empty;

            DataTable dtClassToCost = FileToDataTable.GetDataTableFromCSV("class-to-cost.csv");
            DataTable dtZip3ToClass = FileToDataTable.GetDataTableFromCSV("zip3-to-class.csv");

            foreach (DataRow row in dtZip3ToClass.Rows)
            {
                if (row["zip"].ToString() == zip3)
                {
                    areaClass = row["area class"].ToString();
                    break;
                }
            }
            foreach (DataRow row in dtClassToCost.Rows)
            {
                if (row["area class"].ToString() == areaClass)
                {
                    cost = row["cost"].ToString();
                    break;
                }
            }
            return cost;
        }
    }
}
