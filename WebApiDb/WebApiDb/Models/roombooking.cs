using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDb.Models
{
    public class roombooking
    {
        public int roombookingid { get; set; }
        public string name { get; set; }
        public int genderid { get; set; }
        public string mobilenumber { get; set; }
        public int idprooftypeid { get; set; }
        public string idproofnumber { get; set; }
        public string fulladdress { get; set; }
        public int roomtypeid	{get;set;}
        public int roomnumberid { get; set; }
        public double roompriceperday { get; set; }
        public string fromdate { get; set; }
        public string numberofpeople { get; set; }
        public string peoplenames { get; set; }
        public int extrabedcount { get; set; }
        public int extrabedpriceperday { get; set; }
        public double advanceamount { get; set; }
        public string paymentdate { get; set; }
        public int paymentmodeid { get; set; }
        public string transactiondetails { get; set; }
        public int roomstatusid { get; set; }
        public string rbstatus { get; set; }
    }
}