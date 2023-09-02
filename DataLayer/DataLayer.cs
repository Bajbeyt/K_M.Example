using System;
using System.Data.SqlClient;
namespace DataLayer
{
    public class DbConnection
    {
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=PersonnelTracking;User Id=SA;Password=reallyStrongPwd123;MultipleActiveResultSets=true;TrustServerCertificate=true;");
            connection.Open();
            return connection;
        }
        public SqlCommand CreateCommand(string query)
        {
            SqlCommand sqlCommand = new SqlCommand(query, OpenConnection());
            return sqlCommand;
        }
        public SqlDataReader DataReader(string query)
        {
            SqlCommand command = CreateCommand(query);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}

