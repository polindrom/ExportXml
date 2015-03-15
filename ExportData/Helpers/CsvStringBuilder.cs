using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExportData.Helpers
{
    public class CsvStringBuilder: BaseOutputStringBuilder
    {
        protected override string CreateExportString<T>(IEnumerable<T> dataList)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var result = new StringBuilder();

            //adds headers
            foreach (PropertyInfo propertyInfo in properties)
            {
                result.Append(propertyInfo.Name).Append(",");
            }
            result.Remove(result.Length - 1, 1).AppendLine();

            //fills the spreadsheet 
            foreach (string line in dataList.Select(row => properties.Select(p => p.GetValue(row, null))
                .Select(v => StringToCsvCell(Convert.ToString(v)))).Select(values => string.Join(",", values)))
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        protected string StringToCsvCell(string str)
        {
            bool mustQuote = (str.Contains(",") || str.Contains("\"") || str.Contains("\r") || str.Contains("\n"));
            if (mustQuote)
            {
                var sb = new StringBuilder();
                sb.Append("\"");
                foreach (char nextChar in str)
                {
                    sb.Append(nextChar);
                    if (nextChar == '"')
                        sb.Append("\"");
                }
                sb.Append("\"");
                return sb.ToString();
            }
            return str;
        }
    }
}