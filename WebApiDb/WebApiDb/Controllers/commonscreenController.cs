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
    public class commonscreenController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("commonscreencreate")]
        public string commonscreencreate(commonscreen cs)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONSCREEN_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@COMMONSCREENID", "");
                    command.Parameters.AddWithValue("@MASTERANDCHILDSTATUS", cs.masterandchildstatus);
                    command.Parameters.AddWithValue("@MASTERNAME", cs.mastername);
                    command.Parameters.AddWithValue("@CHILDNAME", cs.childname);
                    command.Parameters.AddWithValue("@MASTERID", cs.masterid);
                    command.Parameters.AddWithValue("@MASTERSTATUS", cs.masterstatus);
                    command.Parameters.AddWithValue("@CHILDSTATUS", cs.childstatus);
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
        [ActionName("commonscreenread")]
        public List<commonscreen> commonscreenread()
        {
            commonscreen cs = new commonscreen();
            List<commonscreen> Lcs = new List<commonscreen>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONSCREEN_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        Lcs.Add(new commonscreen()
                        {
                            coomscreenid = Convert.ToInt32(sdatareader["COMMONSCREENID"]),
                            masterandchildstatus = sdatareader["MASTERANDCHILDSTATUS"].ToString(),
                            mastername = sdatareader["MASTERNAME"].ToString(),
                            childname = sdatareader["CHILDNAME"].ToString(),
                            masterid = Convert.ToInt32(sdatareader["MASTERID"]),
                            masterstatus = sdatareader["MASTERSTATUS"].ToString(),
                            childstatus = sdatareader["CHILDSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Lcs;
        }


        //Read id
        [HttpGet]
        [ActionName("commonscreenread")]
        public commonscreen commonscreenread(int id)
        {
            commonscreen cs = new commonscreen();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONSCREEN_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@COMMONSCREENID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        cs.coomscreenid = Convert.ToInt32(sdatareader["COMMONSCREENID"]);
                        cs.masterandchildstatus = sdatareader["MASTERANDCHILDSTATUS"].ToString();
                        cs.mastername = sdatareader["MASTERNAME"].ToString();
                        cs.childname = sdatareader["CHILDNAME"].ToString();
                        cs.masterid = Convert.ToInt32(sdatareader["MASTERID"]);
                        cs.masterstatus = sdatareader["MASTERSTATUS"].ToString();
                        cs.childstatus = sdatareader["CHILDSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return cs;
        }


        //Update
        [HttpPut]
        [ActionName("commonscreenupdate")]
        public void commonscreenupdate(commonscreen cs)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONSCREEN_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@COMMONSCREENID", cs.coomscreenid);
                    command.Parameters.AddWithValue("@MASTERANDCHILDSTATUS", cs.masterandchildstatus);
                    command.Parameters.AddWithValue("@MASTERNAME", cs.mastername);
                    command.Parameters.AddWithValue("@CHILDNAME", cs.childname);
                    command.Parameters.AddWithValue("@MASTERID", cs.masterid);
                    command.Parameters.AddWithValue("@MASTERSTATUS", cs.masterstatus);
                    command.Parameters.AddWithValue("@CHILDSTATUS", cs.childstatus);
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
        [ActionName("commonscreenupdate")]
        public void commonscreendelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("COMMONSCREEN_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@COMMONSCREENID", id);
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
