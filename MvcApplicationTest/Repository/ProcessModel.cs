using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationTest.Repository
{
    [Serializable]
    public class ProcessModel
    {
        public int BasePriority { get; set; }
        public bool EnableRaisingEvents { get; set; }
        public string ProcessName { get; set; }
        public int HandleCount { get; set; }
        public int Id { get; set; }
        public string MachineName { get; set; }
        public long PeakPagedMemorySize64 { get; set; }
    }
}