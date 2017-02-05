using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using WebApiDb.Models;

namespace WebApiDb.Controllers
{
    public class userregistrationController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["WEBAPIDBCS"].ConnectionString;

        //Create
        [HttpPost]
        [ActionName("userregistrationcreate")]
        public string userregistrationcreate(userregistration ur)
        {
            string savedcount;
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERREGISTRATION_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "C");
                    command.Parameters.AddWithValue("@USERREGISTRATIONID", "");
                    command.Parameters.AddWithValue("@USERNAME", ur.username);
                    command.Parameters.AddWithValue("@PASWORD", ur.pasword);
                    command.Parameters.AddWithValue("@REPASSWORD", ur.repassword);
                    command.Parameters.AddWithValue("@MOBILENUMBER", ur.mobilenumber);
                    command.Parameters.AddWithValue("@EMAILID", ur.emailid);
                    command.Parameters.AddWithValue("@URSTATUS", ur.urstatus);
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
        [ActionName("userregistrationread")]
        public List<userregistration> userregistrationread()
        {
            userregistration ur = new userregistration();
            List<userregistration> Lur = new List<userregistration>();

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERREGISTRATION_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        Lur.Add(new userregistration()
                        {
                            userregistrationid = Convert.ToInt32(sdatareader["USERREGISTRATIONID"]),
                            username = sdatareader["USERNAME"].ToString(),
                            pasword = sdatareader["PASWORD"].ToString(),
                            repassword = sdatareader["REPASSWORD"].ToString(),
                            mobilenumber = sdatareader["MOBILENUMBER"].ToString(),
                            emailid = sdatareader["EMAILID"].ToString(),
                            urstatus = sdatareader["URSTATUS"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Lur;
            }
        }


        //Read id
        [HttpGet]
        [ActionName("userregistrationread")]
        public userregistration userregistrationread(int id)
        {
            userregistration ur = new userregistration();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERREGISTRATION_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "R");
                    command.Parameters.AddWithValue("@USERREGISTRATIONID", id);
                    SqlDataReader sdatareader = null;
                    sdatareader = command.ExecuteReader();
                    while (sdatareader.Read())
                    {
                        ur.userregistrationid = Convert.ToInt32(sdatareader["USERREGISTRATIONID"]);
                        ur.username = sdatareader["USERNAME"].ToString();
                        ur.pasword = sdatareader["PASWORD"].ToString();
                        ur.repassword = sdatareader["REPASSWORD"].ToString();
                        ur.mobilenumber = sdatareader["MOBILENUMBER"].ToString();
                        ur.emailid = sdatareader["EMAILID"].ToString();
                        ur.urstatus = sdatareader["URSTATUS"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return ur;
        }


        //Update
        [HttpPut]
        [ActionName("userregistrationupdate")]
        public void userregistrationupdate(userregistration ur)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERREGISTRATION_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "U");
                    command.Parameters.AddWithValue("@USERREGISTRATIONID", ur.userregistrationid);
                    command.Parameters.AddWithValue("@USERNAME", ur.username);
                    command.Parameters.AddWithValue("@PASWORD", ur.pasword);
                    command.Parameters.AddWithValue("@REPASSWORD", ur.repassword);
                    command.Parameters.AddWithValue("@MOBILENUMBER", ur.mobilenumber);
                    command.Parameters.AddWithValue("@EMAILID", ur.emailid);
                    command.Parameters.AddWithValue("@URSTATUS", ur.urstatus);
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
        [ActionName("userregistrationdelete")]
        public void userregistrationdelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand("USERREGISTRATION_CRUD", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TRANSACTION_TYPE", "D");
                    command.Parameters.AddWithValue("@USERREGISTRATIONID", id);
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
