using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationTest.Repository
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
    }
}