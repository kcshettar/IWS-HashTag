using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRestApi.Model
{
    public class User
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eMail { get; set; }
        public string phone { get; set; }
        public string jobId { get; set; }
    }
}
