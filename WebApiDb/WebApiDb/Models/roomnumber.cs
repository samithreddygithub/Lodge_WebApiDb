using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDb.Models
{
    public class roomnumber
    {  
        public int roomnumberid { get; set; }
	    public int roomtypeid { get; set; }
        public int snoroomnumber { get; set; }
        public int roomstatusid { get; set; } 
        public string rnstatus { get; set; }
    }
}