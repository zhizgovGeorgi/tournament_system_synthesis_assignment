using Entites;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDB : IUserDB<User>
    {
        private MySqlConnection conn;

        public UserDB()
        {
            conn = ConnectionDB.GetConnection();
        }

        public void Add(User u)
        {
            string sqlStatement = "INSERT INTO tournament_user (fName, lName, email, adress,  password, role) VALUES (@fName, @lName,  @email , @adress, @password, role);";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@firstName", u.FName);
            command.Parameters.AddWithValue("@lastname", u.LName);
            command.Parameters.AddWithValue("@email", u.Email);
            command.Parameters.AddWithValue("@adress", u.Adress);
            command.Parameters.AddWithValue("@password", u.Password);
            command.Parameters.AddWithValue("@role", u.Role);
            try
            {
                int n;

                conn.Open();

                n = command.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            finally
            {
                conn.Close();
            }
        }

        public List<User> Read()
        {
            string sqlStatement = "SELECT * FROM tournament_user ";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);
            List<User> users = new List<User>();
            try
            {
                MySqlDataReader databaseReader;

                conn.Open();
                databaseReader = command.ExecuteReader();

                User user;

                while (databaseReader.Read())
                {

                    user = new User(databaseReader.GetInt32("id"), databaseReader.GetString("fName"), databaseReader.GetString("lName"), databaseReader.GetString("email"), databaseReader.GetString("adress"), databaseReader.GetString("password"), databaseReader.GetString("role"));
                    users.Add(user);
                }
                return users;
            }
            catch (MySqlException ex)
            {

                throw ex;

            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(User u)
        {
            string sql = "UPDATE tournament_user SET firstName = @firstName, lastName = @lastName, email = @email, adress = @adress WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", u.Id);
            command.Parameters.AddWithValue("@firstName", u.FName);
            command.Parameters.AddWithValue("@lastname", u.LName);
            command.Parameters.AddWithValue("@email", u.Email);
            command.Parameters.AddWithValue("@adress", u.Adress);
            try
            {

                conn.Open();

                cmd.ExecuteNonQuery();


            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                   conn.Close();
                }
            }

        }
    }
}
