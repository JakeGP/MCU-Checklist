using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MCUChecklist.Models;


namespace MCUChecklist.Helpers
{
    public class AccountHelper
    {
        public static User Login(Login login)
        {
            User user = new User();
            string connString = ConfigurationManager.AppSettings["SqlConnectionString"];

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("MCUCAdmin.uspLogin", conn))
                {
                    

                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UsernameOrEmail", login.UsernameOrEmail).SqlDbType = SqlDbType.NVarChar;
                    command.Parameters.AddWithValue("@Password", login.Password);

                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if(rdr["@responseMessage"].ToString() == "Success")
                            {
                                user.UserID = Convert.ToInt32(rdr["UserID"]);
                                user.Username = rdr["UserCommonName"].ToString();
                            }
                            user.LoginMessage = rdr["@responseMessage"].ToString();
                        }
                    }
                }
            }
            return user;
        }

        public static User AddUser(Register register)
        {
            User user = new User();
            string connString = ConfigurationManager.AppSettings["SqlConnectionString"];

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnectionString"]))
            {
                using (SqlCommand command = new SqlCommand("MCUCAdmin.uspAddUser", conn))
                {
                    conn.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserCommonName", register.UserCommonName).SqlDbType = SqlDbType.NVarChar;
                    command.Parameters.AddWithValue("@UserEmailAddress", register.UserEmailAddress).SqlDbType = SqlDbType.NVarChar;
                    command.Parameters.AddWithValue("@Password", register.Password).SqlDbType = SqlDbType.NVarChar;

                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            if (rdr["@responseMessage"].ToString() == "Success")
                            {
                                user.UserID = Convert.ToInt32(rdr["UserID"]);
                                user.Username = rdr["UserCommonName"].ToString();
                            }
                            user.LoginMessage = rdr["@responseMessage"].ToString();
                        }
                    }
                }
            }
            return user;
        }
    }
}