using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDb.Models
{
    public class roomresadv
    {
        public int roomresadvid { get; set; }
        public string name { get; set; }
        public int genderid { get; set; } 
        public string mobilenumber { get; set; }
        public int roomtypeid	{get;set;}
        public int roomnumberid { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public double totaldays { get; set; }
        public double roomrateperday { get; set; }
        public double advanceamount { get; set; }
        public string paymentdate { get; set; }
        public int paymentmodeid { get; set; }
        public string transactiondetails { get; set; }
        public string notes { get; set; }
        public int roomstatusid { get; set; } 
        public string resadvstatus { get; set; }
    }
}