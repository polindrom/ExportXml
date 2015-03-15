using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace MvcApplicationTest.Helpers
{
    public enum ExportType
    {
        xml,
        csv
    }

    public static class ExportStringBuilder
    {
        /// <summary>
        /// Gets the specific string which need for exportable file.
        /// </summary>
        /// <typeparam name="T">Type of the IEnumerable objects which will be passed into constuctor as dataList parameter.</typeparam>
        /// <param name="exportType">Export data type.</param>
        /// <param name="dataList">List of <see cref="T"/>.</param>
        /// <returns></returns>
        public static string GetExportString<T>(ExportType exportType, IEnumerable<T> dataList)
        {
            string report;
            switch (exportType)
            {
                case ExportType.xml:
                    report = CreateXmlString(dataList);
                    break;

                case ExportType.csv:
                    report = CreateCsvString(dataList);
                    break;

                default:
                    report = String.Empty;
                    break;
            }
            return report;
        }

        private static string CreateXmlString<T>(IEnumerable<T> dataList)
        {
            using (var writer = new StringWriter())
            {
                var xml = new XmlSerializer(dataList.GetType());
                xml.Serialize(writer, dataList);
                return writer.ToString();
            }
        }

        private static string CreateCsvString<T>(IEnumerable<T> data)
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
            foreach (string line in data.Select(row => properties.Select(p => p.GetValue(row, null))
                .Select(v => StringToCsvCell(Convert.ToString(v)))).Select(values => string.Join(",", values)))
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        private static string StringToCsvCell(string str)
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