using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcApplicationTest.Helpers
{
    public class GetReport
    {
        public string GetStringReport(DataTable table)
        {
            string report = "";
            string tab = "";
            foreach (DataColumn dc in table.Columns)
            {
                report += tab + dc.ColumnName;
                tab = "\t";
            }

            report += "\n";

            int i;
            foreach (DataRow dr in table.Rows)
            {
                tab = "";
                for (i = 0; i < table.Columns.Count; i++)
                {
                    report += tab + dr[i];
                    tab = "\t";
                }
                report += "\n";
            }
            return report;
        }
    }
}