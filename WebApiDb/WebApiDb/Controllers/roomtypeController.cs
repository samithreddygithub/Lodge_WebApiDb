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
    public class roomtypeController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("roomtypecreate")]
        public string roomtypecreate(roomtype rt)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMTYPE_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@ROOMTYPEID", "");
                    command.Parameters.AddWithValue("@ROOMNAME", rt.roomname);
                    command.Parameters.AddWithValue("@ROOMPRICEPERDAY", rt.roompriceperday);
                    command.Parameters.AddWithValue("@EXTRABEDCOUNT", rt.extrabedcount);
                    command.Parameters.AddWithValue("@EXTRABEDPRICEPERDAY", rt.etrabedpriceperday);
                    command.Parameters.AddWithValue("@RTSTATUS", rt.rtstatus);
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
        [ActionName("roomtyperead")]
        public List<roomtype> roomtyperead()
        {
            roomtype rt = new roomtype();
            List<roomtype> Lrt = new List<roomtype>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMTYPE_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        Lrt.Add(new roomtype()
                        {
                            roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]),
                            roomname = sdatareader["ROOMNAME"].ToString(),
                            roompriceperday = Convert.ToInt32(sdatareader["ROOMPRICEPERDAY"]),
                            extrabedcount = Convert.ToInt32(sdatareader["EXTRABEDCOUNT"]),
                            etrabedpriceperday = Convert.ToInt32(sdatareader["EXTRABEDPRICEPERDAY"]),
                            rtstatus = sdatareader["RTSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Lrt;
        }


        //Read id
        [HttpGet]
        [ActionName("roomtyperead")]
        public roomtype roomtyperead(int id)
        {
            roomtype rt = new roomtype();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMTYPE_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@ROOMTYPEID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        rt.roomtypeid = Convert.ToInt32(sdatareader["ROOMTYPEID"]);
                        rt.roomname = sdatareader["ROOMNAME"].ToString();
                        rt.roompriceperday = Convert.ToInt32(sdatareader["ROOMPRICEPERDAY"]);
                        rt.extrabedcount = Convert.ToInt32(sdatareader["EXTRABEDCOUNT"]);
                        rt.etrabedpriceperday = Convert.ToInt32(sdatareader["EXTRABEDPRICEPERDAY"]);
                        rt.rtstatus = sdatareader["RTSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rt;
        }


        //Update
        [HttpPut]
        [ActionName("roomtypeupdate")]
        public void roomtypeupdate(roomtype rt)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMTYPE_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@ROOMTYPEID", rt.roomtypeid);
                    command.Parameters.AddWithValue("@ROOMNAME", rt.roomname);
                    command.Parameters.AddWithValue("@ROOMPRICEPERDAY", rt.roompriceperday);
                    command.Parameters.AddWithValue("@EXTRABEDCOUNT", rt.extrabedcount);
                    command.Parameters.AddWithValue("@EXTRABEDPRICEPERDAY", rt.etrabedpriceperday);
                    command.Parameters.AddWithValue("@RTSTATUS", rt.rtstatus);
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
        [ActionName("roomtypeupdate")]
        public void roomtypedelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("ROOMTYPE_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@roomtypeID", id);
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
