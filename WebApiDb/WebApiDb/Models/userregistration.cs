using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDb.Models
{
    public class userregistration
    {
        public int userregistrationid { get; set; }
        public string username { get; set; }
        public string pasword { get; set; }
        public string repassword { get; set; }
        public string mobilenumber { get; set; }
        public string emailid { get; set; }
        public string urstatus { get; set; }
    }
}