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
    public class ScoreDAL
    {
        private string _connectionString;
        public ScoreDAL(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public List<Score> GetList(int userId)
        {
            var listOfScores = new List<Score>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetListOfScores", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userId;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listOfScores.Add(new Score
                        {
                            aces = Convert.ToInt32(rdr[0]),
                            twos = Convert.ToInt32(rdr[1]),
                            threes = Convert.ToInt32(rdr[2]),
                            userId = Convert.ToInt32(rdr[3]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfScores;
        }
    }
}
