using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDb.Models
{
    public class roomtype
    {
        public int roomtypeid { get; set; }
        public string roomname { get; set; }
        public double roompriceperday { get; set; }
        public int extrabedcount { get; set; }
        public double etrabedpriceperday { get; set; }
        public string rtstatus { get; set; }
    }
}