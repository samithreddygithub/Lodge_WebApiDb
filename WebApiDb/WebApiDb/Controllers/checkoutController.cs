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
    public class checkoutController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("checkoutcreate")]
        public string checkoutcreate(checkout co)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHECKOUT_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@CHECKOUTID", "");
                    command.Parameters.AddWithValue("@ROOMTYPEID", co.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", co.roomnumberid);
                    command.Parameters.AddWithValue("@NAME", co.name);
                    command.Parameters.AddWithValue("@GENDERID", co.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", co.mobilenumber);
                    command.Parameters.AddWithValue("@NUMBEROFPEOPLE", co.numberofpeople);
                    command.Parameters.AddWithValue("@PEOPLENAMES", co.peoplenames);
                    command.Parameters.AddWithValue("@CHECKINDATE", co.checkindate);
                    command.Parameters.AddWithValue("@CHECKOUTDATE", co.checkoutdate);
                    command.Parameters.AddWithValue("@TOTALDAYS", co.totaldays);
                    command.Parameters.AddWithValue("@EXTRABEDCOUNT", co.extrabedcount);
                    command.Parameters.AddWithValue("@EXTRABEDRATEPERDAY", co.extrabedrateperday);
                    command.Parameters.AddWithValue("@ROOMRATEPERDAY", co.roomrateperday);
                    command.Parameters.AddWithValue("@TOTALAMOUNT", co.totalamount);
                    command.Parameters.AddWithValue("@TOTALPAIDAMOUNT", co.totalpaidamount);
                    command.Parameters.AddWithValue("@DISCOUNT", co.discount);
                    command.Parameters.AddWithValue("@SERVICETAX", co.servicetax);
                    command.Parameters.AddWithValue("@BALANCEAMOUNT", co.balanceamount);
                    command.Parameters.AddWithValue("@CIRAPID", co.cirapid);
                    command.Parameters.AddWithValue("@PAYMENTDATE", co.paymentdate);
                    command.Parameters.AddWithValue("@PAYINGAMOUNT", co.payingamount);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", co.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", co.transactiondetails);
                    command.Parameters.AddWithValue("@NOTES", co.notes);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", co.roomstatusid);
                    command.Parameters.AddWithValue("@COSTATUS", co.costatus);
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
        [ActionName("checkoutread")]
        public List<checkout> checkoutread()
        {
            checkout co = new checkout();
            List<checkout> lco = new List<checkout>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHECKOUT_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        lco.Add(new checkout()
                        {
                            checkoutid = Convert.ToInt32(sdatareader["CHECKOUTID"]),
                            roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]),
                            roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]),
                            name = sdatareader["NAME"].ToString(),
                            genderid = Convert.ToInt32(sdatareader["GENDERID"]),
                            mobilenumber = sdatareader["MOBILENUMBER"].ToString(),
                            numberofpeople = Convert.ToInt32(sdatareader["NUMBEROFPEOPLE"]),
                            peoplenames = sdatareader["PEOPLENAMES"].ToString(),
                            checkindate = sdatareader["CHECKINDATE"].ToString(),
                            checkoutdate = sdatareader["CHECKOUTDATE"].ToString(),
                            totaldays = Convert.ToDouble(sdatareader["TOTALDAYS"]),
                            extrabedcount = Convert.ToInt32(sdatareader["EXTRABEDCOUNT"]),
                            extrabedrateperday = Convert.ToInt32(sdatareader["EXTRABEDRATEPERDAY"]),
                            roomrateperday = Convert.ToInt32(sdatareader["ROOMRATEPERDAY"]),
                            totalamount = Convert.ToInt32(sdatareader["TOTALAMOUNT"]),
                            totalpaidamount = Convert.ToDouble(sdatareader["TOTALPAIDAMOUNT"]),
                            discount = Convert.ToDouble(sdatareader["DISCOUNT"]),
                            servicetax = Convert.ToDouble(sdatareader["SERVICETAX"]),
                            balanceamount = Convert.ToDouble(sdatareader["BALANCEAMOUNT"]),
                            cirapid = sdatareader["CIRAPID"].ToString(),
                            paymentdate = sdatareader["PAYMENTDATE"].ToString(),
                            payingamount = Convert.ToDouble(sdatareader["PAYINGAMOUNT"]),
                            paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]),
                            transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString(),
                            notes = sdatareader["NOTES"].ToString(),
                            roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]),
                            costatus = sdatareader["COSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return lco;
        }


        //Read id
        [HttpGet]
        [ActionName("checkoutread")]
        public checkout checkoutread(int id)
        {
            checkout co = new checkout();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHECKOUT_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@CHECKOUTID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        co.checkoutid = Convert.ToInt32(sdatareader["CHECKOUTID"]);
                        co.roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]);
                        co.roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]);
                        co.name = sdatareader["NAME"].ToString();
                        co.genderid = Convert.ToInt32(sdatareader["GENDERID"]);
                        co.mobilenumber = sdatareader["MOBILENUMBER"].ToString();
                        co.numberofpeople = Convert.ToInt32(sdatareader["NUMBEROFPEOPLE"]);
                        co.peoplenames = sdatareader["PEOPLENAMES"].ToString();
                        co.checkindate = sdatareader["CHECKINDATE"].ToString();
                        co.checkoutdate = sdatareader["CHECKOUTDATE"].ToString();
                        co.totaldays = Convert.ToDouble(sdatareader["TOTALDAYS"]);
                        co.extrabedcount = Convert.ToInt32(sdatareader["EXTRABEDCOUNT"]);
                        co.extrabedrateperday = Convert.ToInt32(sdatareader["EXTRABEDRATEPERDAY"]);
                        co.roomrateperday = Convert.ToInt32(sdatareader["ROOMRATEPERDAY"]);
                        co.totalamount = Convert.ToInt32(sdatareader["TOTALAMOUNT"]);
                        co.totalpaidamount = Convert.ToDouble(sdatareader["TOTALPAIDAMOUNT"]);
                        co.discount = Convert.ToDouble(sdatareader["DISCOUNT"]);
                        co.servicetax = Convert.ToDouble(sdatareader["SERVICETAX"]);
                        co.balanceamount = Convert.ToDouble(sdatareader["BALANCEAMOUNT"]);
                        co.cirapid = sdatareader["CIRAPID"].ToString();
                        co.paymentdate = sdatareader["PAYMENTDATE"].ToString();
                        co.payingamount = Convert.ToDouble(sdatareader["PAYINGAMOUNT"]);
                        co.paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]);
                        co.transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString();
                        co.notes = sdatareader["NOTES"].ToString();
                        co.roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]);
                        co.costatus = sdatareader["COSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return co;
        }


        //Update
        [HttpPut]
        [ActionName("checkoutupdate")]
        public void checkoutupdate(checkout co)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHECKOUT_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@CHECKOUTID", co.checkoutid);
                    command.Parameters.AddWithValue("@ROOMTYPEID", co.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", co.roomnumberid);
                    command.Parameters.AddWithValue("@NAME", co.name);
                    command.Parameters.AddWithValue("@GENDERID", co.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", co.mobilenumber);
                    command.Parameters.AddWithValue("@NUMBEROFPEOPLE", co.numberofpeople);
                    command.Parameters.AddWithValue("@PEOPLENAMES", co.peoplenames);
                    command.Parameters.AddWithValue("@CHECKINDATE", co.checkindate);
                    command.Parameters.AddWithValue("@CHECKOUTDATE", co.checkoutdate);
                    command.Parameters.AddWithValue("@TOTALDAYS", co.totaldays);
                    command.Parameters.AddWithValue("@EXTRABEDCOUNT", co.extrabedcount);
                    command.Parameters.AddWithValue("@EXTRABEDRATEPERDAY", co.extrabedrateperday);
                    command.Parameters.AddWithValue("@ROOMRATEPERDAY", co.roomrateperday);
                    command.Parameters.AddWithValue("@TOTALAMOUNT", co.totalamount);
                    command.Parameters.AddWithValue("@TOTALPAIDAMOUNT", co.totalpaidamount);
                    command.Parameters.AddWithValue("@DISCOUNT", co.discount);
                    command.Parameters.AddWithValue("@SERVICETAX", co.servicetax);
                    command.Parameters.AddWithValue("@BALANCEAMOUNT", co.balanceamount);
                    command.Parameters.AddWithValue("@CIRAPID", co.cirapid);
                    command.Parameters.AddWithValue("@PAYMENTDATE", co.paymentdate);
                    command.Parameters.AddWithValue("@PAYINGAMOUNT", co.payingamount);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", co.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", co.transactiondetails);
                    command.Parameters.AddWithValue("@NOTES", co.notes);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", co.roomstatusid);
                    command.Parameters.AddWithValue("@COSTATUS", co.costatus);
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
        [ActionName("checkoutupdate")]
        public void checkoutdelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("CHECKOUT_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@CHECKOUTID", id);
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
