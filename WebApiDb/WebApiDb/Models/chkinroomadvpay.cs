using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDb.Models
{
    public class chkinroomadvpay
    {
        public int chkinroomadvpayid { get; set; }
        public int roomtypeid	{get;set;}        
        public int roomnumberid { get; set; }
        public string name { get; set; }
        public int genderid { get; set; }
        public string mobilenumber { get; set; }
        public int numberofpeople { get; set; }
        public string peoplenames { get; set; }
        public string checkindate { get; set; }
        public string paymentdate { get; set; }
        public double payingamount { get; set; }
        public int paymentmodeid { get; set; }
        public string transactiondetails { get; set; }
        public int roomstatusid { get; set; }
        public string cirmadpystatus { get; set; }
    }
}