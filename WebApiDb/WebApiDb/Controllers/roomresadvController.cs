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
    public class roomresadvController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("roomresadvcreate")]
        public string roomresadvcreate(roomresadv rra)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMRESADV_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@ROOMRESADVID", "");
                    command.Parameters.AddWithValue("@NAME", rra.name);
                    command.Parameters.AddWithValue("@GENDERID", rra.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", rra.mobilenumber);
                    command.Parameters.AddWithValue("@ROOMTYPEID", rra.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", rra.roomnumberid);
                    command.Parameters.AddWithValue("@FROMDATE", rra.fromdate);
                    command.Parameters.AddWithValue("@TODATE", rra.fromdate);
                    command.Parameters.AddWithValue("@TOTALDAYS", rra.totaldays);
                    command.Parameters.AddWithValue("@ROOMRATEPERDAY", rra.roomrateperday);
                    command.Parameters.AddWithValue("@ADVANCEAMOUNT", rra.advanceamount);
                    command.Parameters.AddWithValue("@PAYMENTDATE", rra.paymentdate);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", rra.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", rra.transactiondetails);
                    command.Parameters.AddWithValue("@NOTES", rra.notes);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", rra.roomstatusid);
                    command.Parameters.AddWithValue("@RESADVSTATUS", rra.resadvstatus);
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
        [ActionName("roomresadvread")]
        public List<roomresadv> roomresadvread()
        {
            roomresadv rra = new roomresadv();
            List<roomresadv> Lrra = new List<roomresadv>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMRESADV_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        Lrra.Add(new roomresadv()
                        {
                            roomresadvid = Convert.ToInt32(sdatareader["ROOMRESADVID"]),
                            name = sdatareader["NAME"].ToString(),
                            genderid = Convert.ToInt32(sdatareader["GENDERID"]),
                            mobilenumber = sdatareader["MOBILENUMBER"].ToString(),
                            roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]),
                            roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]),
                            fromdate = sdatareader["FROMDATE"].ToString(),
                            todate = sdatareader["TODATE"].ToString(),
                            totaldays = Convert.ToDouble(sdatareader["TOTALDAYS"]),
                            roomrateperday = Convert.ToDouble(sdatareader["ROOMRATEPERDAY"]),
                            advanceamount = Convert.ToDouble(sdatareader["ADVANCEAMOUNT"]),
                            paymentdate = sdatareader["PAYMENTDATE"].ToString(),
                            paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]),
                            transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString(),
                            notes = sdatareader["NOTES"].ToString(),
                            roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]),
                            resadvstatus = sdatareader["RESADVSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Lrra;
        }


        //Read id
        [HttpGet]
        [ActionName("roomresadvread")]
        public roomresadv roomresadvread(int id)
        {
            roomresadv rra = new roomresadv();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMRESADV_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@ROOMRESADVID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        rra.roomresadvid = Convert.ToInt32(sdatareader["ROOMRESADVID"]);
                        rra.name = sdatareader["NAME"].ToString();
                        rra.genderid = Convert.ToInt32(sdatareader["GENDERID"]);
                        rra.mobilenumber = sdatareader["MOBILENUMBER"].ToString();
                        rra.roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]);
                        rra.roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]);
                        rra.fromdate = sdatareader["FROMDATE"].ToString();
                        rra.fromdate = sdatareader["TODATE"].ToString();
                        rra.totaldays = Convert.ToDouble(sdatareader["TOTALDAYS"]);
                        rra.roomrateperday = Convert.ToDouble(sdatareader["ROOMRATEPERDAY"]);
                        rra.advanceamount = Convert.ToDouble(sdatareader["ADVANCEAMOUNT"]);
                        rra.paymentdate = sdatareader["PAYMENTDATE"].ToString();
                        rra.paymentmodeid = Convert.ToInt32(sdatareader["PAYMENTMODEID"]);
                        rra.transactiondetails = sdatareader["TRANSACTIONDETAILS"].ToString();
                        rra.notes = sdatareader["NOTES"].ToString();
                        rra.roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]);
                        rra.resadvstatus = sdatareader["RESADVSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rra;
        }


        //Update
        [HttpPut]
        [ActionName("roomresadvupdate")]
        public void roomresadvupdate(roomresadv rra)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMRESADV_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@ROOMRESADVID", rra.roomresadvid);
                    command.Parameters.AddWithValue("@NAME", rra.name);
                    command.Parameters.AddWithValue("@GENDERID", rra.genderid);
                    command.Parameters.AddWithValue("@MOBILENUMBER", rra.mobilenumber);
                    command.Parameters.AddWithValue("@ROOMTYPEID", rra.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNUMBERID", rra.roomnumberid);
                    command.Parameters.AddWithValue("@FROMDATE", rra.fromdate);
                    command.Parameters.AddWithValue("@TODATE", rra.fromdate);
                    command.Parameters.AddWithValue("@TOTALDAYS", rra.totaldays);
                    command.Parameters.AddWithValue("@ROOMRATEPERDAY", rra.roomrateperday);
                    command.Parameters.AddWithValue("@ADVANCEAMOUNT", rra.advanceamount);
                    command.Parameters.AddWithValue("@PAYMENTDATE", rra.paymentdate);
                    command.Parameters.AddWithValue("@PAYMENTMODEID", rra.paymentmodeid);
                    command.Parameters.AddWithValue("@TRANSACTIONDETAILS", rra.transactiondetails);
                    command.Parameters.AddWithValue("@NOTES", rra.notes);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", rra.roomstatusid);
                    command.Parameters.AddWithValue("@RESADVSTATUS", rra.resadvstatus);
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
        [ActionName("roomresadvupdate")]
        public void roomresadvdelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMRESADV_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@ROOMRESADVID", id);
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
