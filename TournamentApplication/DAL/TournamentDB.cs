using MySql.Data.MySqlClient;
using System.Data;
using LogicLayer;

namespace DAL
{
    public class TournamentDB : ITournamentDB<Tournament>
    {
        private MySqlConnection conn;
        private SystemDivider divider;
        public TournamentDB()
        {
            conn = ConnectionDB.GetConnection();
            divider = new SystemDivider();
        }


        public void SignForTournament(Tournament t, User u)
        {
            string sqlStatement = "INSERT INTO user_at_tournament ( tournamentId, userId) VALUES ( @tournamentId, @userId);";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@tournamentId", t.Id);
            command.Parameters.AddWithValue("@userId", u.Id);
            try
            {
                int n;

                conn.Open();
                n = command.ExecuteNonQuery();
                // t.AssignCompetitor(u);

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



        public void GetAllTournamentsAndParticipants(List<Tournament> tournaments)
        {
            string sqlStatement = "SELECT * FROM tournament; SELECT ut.tournamentId, ut.userId, u.fName, u.lName, u.email, u.adress, u.password, u.role  FROM user_at_tournament as ut inner join tournament_user as u on ut.userId=u.id ;";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            try
            {
                conn.Open();
                using (DataSet dataSet = new DataSet())
                {
                    adapter.Fill(dataSet);
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        List<User> users = new List<User>();

                        for (int j = 0; j < dataSet.Tables[1].Rows.Count; j++)
                        {
                            if (Convert.ToInt32(dataSet.Tables[1].Rows[j][0]) == Convert.ToInt32(dataSet.Tables[0].Rows[i][0]))
                            {
                                User user = new User(Convert.ToInt32(dataSet.Tables[1].Rows[j][1]), dataSet.Tables[1].Rows[j][2].ToString(), dataSet.Tables[1].Rows[j][2].ToString(), dataSet.Tables[1].Rows[j][3].ToString(), dataSet.Tables[1].Rows[j][4].ToString(), dataSet.Tables[1].Rows[j][5].ToString(), dataSet.Tables[1].Rows[j][6].ToString());
                                users.Add(user);

                            }
                        }
                        Status status = (Status)Enum.Parse(typeof(Status), dataSet.Tables[0].Rows[i][9].ToString(), true);
                        Tournament tournament = new Tournament(Convert.ToInt32(dataSet.Tables[0].Rows[i][0]), dataSet.Tables[0].Rows[i][1].ToString(), dataSet.Tables[0].Rows[i][2].ToString(), Convert.ToDateTime(dataSet.Tables[0].Rows[i][3]), Convert.ToDateTime(dataSet.Tables[0].Rows[i][4]), Convert.ToInt32(dataSet.Tables[0].Rows[i][5]), Convert.ToInt32(dataSet.Tables[0].Rows[i][6]), dataSet.Tables[0].Rows[i][7].ToString(), divider.DivideTournamentSystems(dataSet.Tables[0].Rows[i][8].ToString()), status);
                        tournament.AssignPlayers(users);
                        tournaments.Add(tournament);
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


        public void AddTournament(Tournament t)
        {
            string sqlStatement = "INSERT INTO tournament ( name, description, startDate, endDate,  minCompetitors, maxCompetitors, adress, tournamentSystem, status) VALUES ( @name, @description, @startDate, @endDate,  @minCompetitors, @maxCompetitors, @adress, @tournamentSystem, @status);";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@startDate", t.StartDate);
            command.Parameters.AddWithValue("@endDate", t.EndDate);
            command.Parameters.AddWithValue("@minCompetitors", t.MinCompetitors);
            command.Parameters.AddWithValue("@maxCompetitors", t.MaxCompetitors);
            command.Parameters.AddWithValue("@adress", t.Adress);
            command.Parameters.AddWithValue("@tournamentSystem", t.TournamentSystem.ToString());
            command.Parameters.AddWithValue("@status", t.Status.ToString());
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
            catch (MyException ex)
            {
                throw ex;

            }
            finally
            {
                conn.Close();
            }
        }


        public int GetNextID()
        {
            string sql = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbi463263' AND TABLE_NAME = 'tournament';";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

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




        public void EditTournament(Tournament t)
        {
            string sql = "UPDATE tournament SET name = @name, description=@description, startDate = @startDate, endDate = @endDate, minCompetitors = @minCompetitors, maxCompetitors = @maxCompetitors, adress=@adress, tournamentSystem=@tournamentSystem WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);

            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@startDate", t.StartDate);
            command.Parameters.AddWithValue("@endDate", t.EndDate);
            command.Parameters.AddWithValue("@minCompetitors", t.MinCompetitors);
            command.Parameters.AddWithValue("@maxCompetitors", t.MaxCompetitors);
            command.Parameters.AddWithValue("@adress", t.Adress);
            command.Parameters.AddWithValue("@tournamentSystem", t.TournamentSystem.ToString());
            try
            {

                conn.Open();

                command.ExecuteNonQuery();


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

        public void UpdateTournamentStatus(Tournament t, Status status)
        {
            string sql = "UPDATE tournament SET status = @status WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);

            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@status", status.ToString());
            try
            {

                conn.Open();

                command.ExecuteNonQuery();


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