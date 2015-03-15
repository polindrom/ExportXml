using System;
using System.Collections.Generic;

namespace ExportData.Helpers
{
    public abstract class BaseOutputStringBuilder: IOutputStringBuilder
    {
        public string GetExportString<T>(IEnumerable<T> dataList)
        {
            try
            {
                return CreateExportString<T>(dataList);
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        protected abstract string CreateExportString<T>(IEnumerable<T> dataList);
    }
}