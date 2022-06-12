using LogicLayer;
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
        private SystemDivider divider;
        public UserDB()
        {
            conn = ConnectionDB.GetConnection();
            divider = new SystemDivider();
        }

        public void Add(User u)
        {
            string sqlStatement = "INSERT INTO tournament_user (fName, lName, email, adress,  password, role) VALUES (@fName, @lName,  @email , @adress, @password, @role);";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@fName", u.FName);
            command.Parameters.AddWithValue("@lName", u.LName);
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


        public void GetAllTournamentsForParticipants(List<User> users)
        {
            string sqlStatement = "SELECT * FROM tournament_user; SELECT ut.userId, ut.tournamentId, t.name, t.description, t.startDate, t.endDate, t.minCompetitors, t.maxCompetitors, t.adress, t.tournamentSystem, t.status from user_at_tournament as ut INNER JOIN tournament as t on ut.tournamentId = t.id";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);
            UserDB userDB = new UserDB();
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            try
            {
                using (DataSet dataSet = new DataSet())
                {


                    adapter.Fill(dataSet);
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        List<Tournament> tournaments = new List<Tournament>();

                        for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
                        {
                            if (Convert.ToInt32(dataSet.Tables[1].Rows[j][0]) == Convert.ToInt32(dataSet.Tables[0].Rows[i][0]))
                            {
                                Status status = (Status)Enum.Parse(typeof(Status), dataSet.Tables[1].Rows[j][10].ToString(), true);
                                Tournament tournament = new Tournament(Convert.ToInt32(dataSet.Tables[1].Rows[j][1]), dataSet.Tables[1].Rows[j][2].ToString(), dataSet.Tables[1].Rows[j][3].ToString(), Convert.ToDateTime(dataSet.Tables[1].Rows[j][4]), Convert.ToDateTime(dataSet.Tables[1].Rows[j][5]), Convert.ToInt32(dataSet.Tables[1].Rows[j][6]), Convert.ToInt32(dataSet.Tables[1].Rows[j][7]), dataSet.Tables[1].Rows[j][8].ToString(), divider.DivideTournamentSystems(dataSet.Tables[1].Rows[j][9].ToString()), status);
                                tournaments.Add(tournament);
                            }
                        }

                        User user = new User(Convert.ToInt32(dataSet.Tables[0].Rows[i][0]), dataSet.Tables[0].Rows[i][1].ToString(), dataSet.Tables[0].Rows[i][2].ToString(), dataSet.Tables[0].Rows[i][3].ToString(), dataSet.Tables[0].Rows[i][4].ToString(), dataSet.Tables[0].Rows[i][5].ToString(), dataSet.Tables[0].Rows[i][6].ToString());
                        user.AssingTournaments(tournaments);
                        users.Add(user);

                    }
                }
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
        

        public User ReadUser(int id)
        {
            string sqlStatement = "SELECT * FROM tournament_user WHERE id = @id ";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                MySqlDataReader databaseReader;

                conn.Open();
                databaseReader = command.ExecuteReader();

                User user;

                while (databaseReader.Read())
                {

                   return user = new User(databaseReader.GetInt32("id"), databaseReader.GetString("fName"), databaseReader.GetString("lName"), databaseReader.GetString("email"), databaseReader.GetString("adress"), databaseReader.GetString("password"), databaseReader.GetString("role"));
                }
                return null;
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
            string sql = "UPDATE tournament_user SET fName = @fName, lName = @lName, email = @email, adress = @adress WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", u.Id);
            command.Parameters.AddWithValue("@fName", u.FName);
            command.Parameters.AddWithValue("@lName", u.LName);
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
