using System;
using DataLayer;
using System.Data.SqlClient;
namespace BusinesLayer
{
    public class MyBusinesCode
    {
        DbConnection dbConnection = new DbConnection();

        public void InsertData(string name, string surname, string schoolName, string jop)
        {
            
            SqlCommand command = dbConnection.CreateCommand("INSERT INTO Personnel (Name,Surname,SchoolName,Jop) VALUES (@Name,@Surname,@SchoolName,@Jop)");
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Surname", surname);
            command.Parameters.AddWithValue("@SchoolName", schoolName);
            command.Parameters.AddWithValue("@Jop", jop);
            command.ExecuteNonQuery();

        }
        public void UpdateData(int id,string name, string surname, string schoolName, string jop)
        {
            SqlCommand command = dbConnection.CreateCommand("UPDATE Personnel SET Name=@Name,Surname=@Surname,SchoolName=@SchoolName,Jop=@Jop WHERE Id=@Id");
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Surname", surname);
            command.Parameters.AddWithValue("@SchoolName", schoolName);
            command.Parameters.AddWithValue("@Jop", jop);
            command.ExecuteNonQuery();
        }
        public void DeleteUser(int id)
        {
            SqlCommand command = dbConnection.CreateCommand("DELETE FROM Personnel WHERE Id=@Id");
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
        public List<Personnel> ListUsers()
        {
           
            List<Personnel> personnel1 =new List<Personnel>();
            SqlDataReader reader = dbConnection.DataReader("SELECT * FROM Personnel");
            while (reader.Read())
            {
                Personnel personnel = new Personnel();
                personnel.Id=Convert.ToInt32(reader["Id"]);
                personnel.Name = reader["Name"].ToString();
                personnel.Surname = reader["Surname"].ToString();
                personnel.SchoolName = reader["SchoolName"].ToString();
                personnel.Jop= reader["Jop"].ToString();
                personnel1.Add(personnel);

            }return personnel1;
        }

    }

}

