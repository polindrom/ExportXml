using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcApplicationTest.ActionResults
{
    public class ExcelResult : ActionResult
    {
        public ExcelResult(string fileName, string report)
        {
            this.Filename = fileName;
            this.Report = report;
        }
        public string Report { get; private set; }
        public string Filename { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.BufferOutput = true;

            string fileName = DateTime.Now.ToString("ddmmyyyyhhss") + ".csv";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);

            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.Write(Report);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }
}