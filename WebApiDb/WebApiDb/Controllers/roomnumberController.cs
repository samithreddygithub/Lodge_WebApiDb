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
    public class roomnumberController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("roomnumbercreate")]
        public string roomnumbercreate(roomnumber rn)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMNUMBER_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@ROOMTYPEID", "");
                    command.Parameters.AddWithValue("@ROOMSERIALNUMBER", rn.snoroomnumber);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", rn.roomstatusid);
                    command.Parameters.AddWithValue("@RNSTATUS", rn.rnstatus);
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
        [ActionName("roomnumberread")]
        public List<roomnumber> roomnumberread()
        {
            roomnumber rn = new roomnumber();
            List<roomnumber> Lrn = new List<roomnumber>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMNUMBER_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        Lrn.Add(new roomnumber()
                        {
                            roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]),
                            roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]),
                            snoroomnumber = Convert.ToInt32(sdatareader["ROOMSERIALNUMBER"]),
                            roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]),
                            rnstatus = sdatareader["RNSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Lrn;
        }


        //Read id
        [HttpGet]
        [ActionName("roomnumberread")]
        public roomnumber roomnumberread(int id)
        {
            roomnumber rn = new roomnumber();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMNUMBER_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@ROOMNUMBERID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        rn.roomnumberid = Convert.ToInt32(sdatareader["ROOMNUMBERID"]);
                        rn.roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]);
                        rn.snoroomnumber = Convert.ToInt32(sdatareader["ROOMSERIALNUMBER"]);
                        rn.roomstatusid = Convert.ToInt32(sdatareader["ROOMSTATUSID"]);
                        rn.rnstatus = sdatareader["RNSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rn;
        }


        //Update
        [HttpPut]
        [ActionName("roomnumberupdate")]
        public void roomnumberupdate(roomnumber rn)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMNUMBER_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@ROOMNUMBERID", rn.roomnumberid);
                    command.Parameters.AddWithValue("@ROOMTYPEID", rn.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMSERIALNUMBER", rn.snoroomnumber);
                    command.Parameters.AddWithValue("@ROOMSTATUSID", rn.roomstatusid);
                    command.Parameters.AddWithValue("@RNSTATUS", rn.rnstatus);
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
        [ActionName("roomnumberupdate")]
        public void roomnumberdelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMNUMBER_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@ROOMNUMBERID", id);
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
