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
    public class roombookingController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("roombookingcreate")]
        public string roombookingcreate(roombooking rb)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMBOOKING_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("ROOMBOOKINGBID", "");
                    command.Parameters.AddWithValue("@NAME", rb.name);
                    command.Parameters.AddWithValue("@GENDERID", rb.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", rb.mobilenumber);
                    command.Parameters.AddWithValue("@IDPROOFTYPEID", rb.idprooftypeid);
                    command.Parameters.AddWithValue("@IDPROOFNUMBER", rb.idproofnumber);
                    command.Parameters.AddWithValue("@FULLADDRESS", rb.fulladdress);
                    command.Parameters.AddWithValue("@ROOMTYPEID", rb.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", rb.roomnumberid);
                    command.Parameters.AddWithValue("@ROOMPRICEPERDAY", rb.roompriceperday);
                    command.Parameters.AddWithValue("@FROMDATE", rb.fromdate);
                    command.Parameters.AddWithValue("@NUMBEROFPEOPLE", rb.numberofpeople);
                    command.Parameters.AddWithValue("@PEOPLENAMES", rb.peoplenames);
                    command.Parameters.AddWithValue("@EXTRABEDCOUNT", rb.extrabedcount);
                    command.Parameters.AddWithValue("@EXTRABEDPRICEPERDAY", rb.extrabedpriceperday);
                    command.Parameters.AddWithValue("@ADVANCEAMOUNT", rb.advanceamount);
                    command.Parameters.AddWithValue("@PAYMENTDATE", rb.paymentdate);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", rb.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", rb.transactiondetails);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", rb.roomstatusid);
                    command.Parameters.AddWithValue("@RBSTATUS", rb.rbstatus);
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
        [ActionName("roombookingread")]
        public List<roombooking> roombookingread()
        {
            roombooking rb = new roombooking();
            List<roombooking> Lrb = new List<roombooking>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMBOOKING_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        Lrb.Add(new roombooking()
                        {
                            roombookingid = Convert.ToInt32(sdatareader["ROOMBOOKINGID"]),
                            name = sdatareader["NAME"].ToString(),
                            genderid = Convert.ToInt32(sdatareader["GENDERID"]),
                            mobilenumber = sdatareader["MOBILENUMBER"].ToString(),
                            idprooftypeid = Convert.ToInt32(sdatareader["IDPROOFTYPEID"]),
                            idproofnumber = sdatareader["IDPROOFNUMBER"].ToString(),
                            fulladdress = sdatareader["FULLADDRESS"].ToString(),
                            roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]),
                            roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]),
                            roompriceperday = Convert.ToDouble(sdatareader["ROOMPRICEPERDAY"]),
                            fromdate = sdatareader["FROMDATE"].ToString(),
                            numberofpeople = sdatareader["NUMBEROFPEOPLE"].ToString(),
                            peoplenames = sdatareader["PEOPLENAMES"].ToString(),
                            extrabedcount = Convert.ToInt32(sdatareader["EXTRABEDCOUNT"]),
                            extrabedpriceperday = Convert.ToInt32(sdatareader["EXTRABEDPRICEPERDAY"]),
                            advanceamount = Convert.ToDouble(sdatareader["ADVANCEAMOUNT"]),
                            paymentdate = sdatareader["PAYMENTDATE"].ToString(),
                            paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]),
                            transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString(),
                            roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]),
                            rbstatus = sdatareader["RBSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Lrb;
        }


        //Read id
        [HttpGet]
        [ActionName("roombookingread")]
        public roombooking roombookingread(int id)
        {
            roombooking rb = new roombooking();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMBOOKING_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@ROOMBOOKINGID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        rb.roombookingid = Convert.ToInt32(sdatareader["ROOMBOOKINGID"]);
                        rb.name = sdatareader["NAME"].ToString();
                        rb.genderid = Convert.ToInt32(sdatareader["GENDERID"]);
                        rb.mobilenumber = sdatareader["MOBILENUMBER"].ToString();
                        rb.idprooftypeid = Convert.ToInt32(sdatareader["IDPROOFTYPEID"]);
                        rb.idproofnumber = sdatareader["IDPROOFNUMBER"].ToString();
                        rb.fulladdress = sdatareader["FULLADDRESS"].ToString();
                        rb.roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]);
                        rb.roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]);
                        rb.roompriceperday = Convert.ToDouble(sdatareader["ROOMPRICEPERDAY"]);
                        rb.fromdate = sdatareader["FROMDATE"].ToString();
                        rb.numberofpeople = sdatareader["NUMBEROFPEOPLE"].ToString();
                        rb.peoplenames = sdatareader["PEOPLENAMES"].ToString();
                        rb.extrabedcount = Convert.ToInt32(sdatareader["EXTRABEDCOUNT"]);
                        rb.extrabedpriceperday = Convert.ToInt32(sdatareader["EXTRABEDPRICEPERDAY"]);
                        rb.advanceamount = Convert.ToDouble(sdatareader["ADVANCEAMOUNT"]);
                        rb.paymentdate = sdatareader["PAYMENTDATE"].ToString();
                        rb.paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]);
                        rb.transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString();
                        rb.roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]);
                        rb.rbstatus = sdatareader["RBSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rb;
        }


        //Update
        [HttpPut]
        [ActionName("roombookingupdate")]
        public void roombookingupdate(roombooking rb)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMBOOKING_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("ROOMBOOKINGBID", rb.roombookingid);
                    command.Parameters.AddWithValue("@NAME", rb.name);
                    command.Parameters.AddWithValue("@GENDERID", rb.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", rb.mobilenumber);
                    command.Parameters.AddWithValue("@IDPROOFTYPEID", rb.idprooftypeid);
                    command.Parameters.AddWithValue("@IDPROOFNUMBER", rb.idproofnumber);
                    command.Parameters.AddWithValue("@FULLADDRESS", rb.fulladdress);
                    command.Parameters.AddWithValue("@ROOMTYPEID", rb.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", rb.roomnumberid);
                    command.Parameters.AddWithValue("@ROOMPRICEPERDAY", rb.roompriceperday);
                    command.Parameters.AddWithValue("@FROMDATE", rb.fromdate);
                    command.Parameters.AddWithValue("@NUMBEROFPEOPLE", rb.numberofpeople);
                    command.Parameters.AddWithValue("@PEOPLENAMES", rb.peoplenames);
                    command.Parameters.AddWithValue("@EXTRABEDCOUNT", rb.extrabedcount);
                    command.Parameters.AddWithValue("@EXTRABEDPRICEPERDAY", rb.extrabedpriceperday);
                    command.Parameters.AddWithValue("@ADVANCEAMOUNT", rb.advanceamount);
                    command.Parameters.AddWithValue("@PAYMENTDATE", rb.paymentdate);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", rb.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", rb.transactiondetails);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", rb.roomstatusid);
                    command.Parameters.AddWithValue("@RBSTATUS", rb.rbstatus);
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
        [ActionName("roombookingupdate")]
        public void roombookingdelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMBOOKING_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@ROOMBOOKINGID", id);
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
