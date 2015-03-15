using System.Collections.Generic;

namespace ExportData.Helpers
{
    public interface IOutputStringBuilder
    {
        string GetExportString<T>(IEnumerable<T> dataList);
    }
}
