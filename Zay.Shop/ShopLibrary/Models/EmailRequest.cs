using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Models
{
    public class EmailRequest
    {

        public List<string> ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        //public List<KeyValuePair<string>> PlaceHolder { get; set; }
        public bool IsBodyHtml { get; set; }

    }
}
