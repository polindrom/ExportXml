using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExportData.Helpers
{
    public class XmlStringBuilder: BaseOutputStringBuilder
    {
        protected override string CreateExportString<T>(IEnumerable<T> dataList)
        {
            using (var writer = new StringWriter())
            {
                var xml = new XmlSerializer(dataList.GetType());
                xml.Serialize(writer, dataList);
                return writer.ToString();
            }
        }
    }
}