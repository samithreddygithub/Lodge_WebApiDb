using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDb.Models;

namespace WebApiDb.Controllers
{
    public class chkinroomadvpayController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("chkinroomadvpaycreate")]
        public string chkinroomadvpaycreate(chkinroomadvpay crap)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHKINROOMADVPAY_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@CHKINROOMADVPAYID", "");
                    command.Parameters.AddWithValue("@ROOMTYPEID", crap.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", crap.roomnumberid);
                    command.Parameters.AddWithValue("@NAME", crap.name);
                    command.Parameters.AddWithValue("@GENDERID", crap.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", crap.mobilenumber);
                    command.Parameters.AddWithValue("@NUMBEROFPEOPLE", crap.numberofpeople);
                    command.Parameters.AddWithValue("@PEOPLENAMES", crap.peoplenames);
                    command.Parameters.AddWithValue("@CHECKINDATE", crap.checkindate);
                    command.Parameters.AddWithValue("@PAYMENTDATE", crap.paymentdate);
                    command.Parameters.AddWithValue("@PAYINGAMOUNT", crap.payingamount);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", crap.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", crap.transactiondetails);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", crap.roomstatusid);
                    command.Parameters.AddWithValue("@CIRMADPYSTATUS", crap.cirmadpystatus);
                    savedcount = command.ExecuteNonQuery().ToString();
                }
                catch (Exception ex)
                {
                    savedcount = ex.ToString();
                }
            }
            return savedcount;
        }


        //Read
        [HttpGet]
        [ActionName("chkinroomadvpayread")]
        public List<chkinroomadvpay> chkinroomadvpayread()
        {
            chkinroomadvpay crap = new chkinroomadvpay();
            List<chkinroomadvpay> lcrap = new List<chkinroomadvpay>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHKINROOMADVPAY_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        lcrap.Add(new chkinroomadvpay()
                        {
                            chkinroomadvpayid = Convert.ToInt32(sdatareader["CHKINROOMADVPAYID"]),
                            roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]),
                            roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]),
                            name = sdatareader["NAME"].ToString(),
                            genderid = Convert.ToInt32(sdatareader["GENDERID"]),
                            mobilenumber = sdatareader["MOBILENUMBER"].ToString(),
                            numberofpeople = Convert.ToInt32(sdatareader["NUMBEROFPEOPLE"]),
                            peoplenames = sdatareader["PEOPLENAMES"].ToString(),
                            checkindate = sdatareader["CHECKINDATE"].ToString(),
                            paymentdate = sdatareader["PAYMENTDATE"].ToString(),
                            payingamount = Convert.ToDouble(sdatareader["PAYINGAMOUNT"]),
                            paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]),
                            transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString(),
                            roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]),
                            cirmadpystatus = sdatareader["CIRMADPYSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lcrap;
        }


        //Read id
        [HttpGet]
        [ActionName("chkinroomadvpayread")]
        public chkinroomadvpay chkinroomadvpayread(int id)
        {
            chkinroomadvpay crap = new chkinroomadvpay();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHKINROOMADVPAY_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@CHKINROOMADVPAYID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        crap.chkinroomadvpayid = Convert.ToInt32(sdatareader["CHKINROOMADVPAYID"]);
                        crap.roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]);
                        crap.roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]);
                        crap.name = sdatareader["NAME"].ToString();
                        crap.genderid = Convert.ToInt32(sdatareader["GENDERID"]);
                        crap.mobilenumber = sdatareader["MOBILENUMBER"].ToString();
                        crap.numberofpeople = Convert.ToInt32(sdatareader["NUMBEROFPEOPLE"]);
                        crap.peoplenames = sdatareader["PEOPLENAMES"].ToString();
                        crap.checkindate = sdatareader["CHECKINDATE"].ToString();
                        crap.paymentdate = sdatareader["PAYMENTDATE"].ToString();
                        crap.payingamount = Convert.ToDouble(sdatareader["PAYINGAMOUNT"]);
                        crap.paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]);
                        crap.transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString();
                        crap.roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]);
                        crap.cirmadpystatus = sdatareader["CIRMADPYSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return crap;
        }


        //Update
        [HttpPut]
        [ActionName("chkinroomadvpayupdate")]
        public void chkinroomadvpayupdate(chkinroomadvpay crap)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHKINROOMADVPAY_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@CHKINROOMADVPAYID", crap.chkinroomadvpayid);
                    command.Parameters.AddWithValue("@ROOMTYPEID", crap.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", crap.roomnumberid);
                    command.Parameters.AddWithValue("@NAME", crap.name);
                    command.Parameters.AddWithValue("@GENDERID", crap.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", crap.mobilenumber);
                    command.Parameters.AddWithValue("@NUMBEROFPEOPLE", crap.numberofpeople);
                    command.Parameters.AddWithValue("@PEOPLENAMES", crap.peoplenames);
                    command.Parameters.AddWithValue("@CHECKINDATE", crap.checkindate);
                    command.Parameters.AddWithValue("@PAYMENTDATE", crap.paymentdate);
                    command.Parameters.AddWithValue("@PAYINGAMOUNT", crap.payingamount);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", crap.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", crap.transactiondetails);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", crap.roomstatusid);
                    command.Parameters.AddWithValue("@CIRMADPYSTATUS", crap.cirmadpystatus);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        //Delete
        [HttpDelete]
        [ActionName("chkinroomadvpayupdate")]
        public void chkinroomadvpaydelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHKINROOMADVPAY_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@CHKINROOMADVPAYID", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
