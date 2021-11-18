using DatabaseConnection.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.DAL
{
    public class UserDAL
    {
        private string _connectionString;
        public UserDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public List<User> GetList(int userId)
        {
            var listOfUsers = new List<User>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetListOfUsers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userId;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listOfUsers.Add(new User
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            username = rdr[1].ToString(),
                            password = rdr[2].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfUsers;
        }

        public List<User> GetUserNameAndPassword(string userName, string pass)
        {
            var listOfUsers = new List<User>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tb_users WHERE username = @userName AND password = @pass", con);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = userName;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listOfUsers.Add(new User
                    {
                        Id = Convert.ToInt32(rdr[0]),
                        username = rdr[1].ToString(),
                        password = rdr[2].ToString()
                    });
                }
            }
            return listOfUsers;
        }
    }
}
