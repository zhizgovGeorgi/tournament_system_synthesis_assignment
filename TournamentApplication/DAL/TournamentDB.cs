using MySql.Data.MySqlClient;
using Entites;
using System.Data;

namespace DAL
{
    public class TournamentDB : ITournamentDB<Tournament>
    {
        private MySqlConnection conn;

        public TournamentDB()
        {
            conn = ConnectionDB.GetConnection();
        }

        public void DeleteTournament(Tournament t)
        {
            string sqlStatement = "DELETE FROM tournament WHERE id = @id;";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@id", t.Id);

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
        public List<Tournament> GetAllTournaments()
        {
            string sqlStatement = "SELECT * FROM tournament";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);
            List<Tournament> tournaments = new List<Tournament>();
            try
            {
                MySqlDataReader databaseReader;

                conn.Open();
                databaseReader = command.ExecuteReader();
                Tournament tournament;

                while (databaseReader.Read())
                {
                    tournament = new Tournament(databaseReader.GetInt32("prod_id"), databaseReader.GetString("name"),databaseReader.GetString("description"), databaseReader.GetDateTime("startDate"), databaseReader.GetDateTime("endDate"), databaseReader.GetInt32("minCompetitors"), databaseReader.GetInt32("maxCompetitors"), databaseReader.GetString("adress"), databaseReader.GetString("tournamentSystem"));
                    tournaments.Add(tournament);
                }
                return tournaments;
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
            string sqlStatement = "INSERT INTO tournament ( name, startDate, endDate,  minCompetitors, maxCompetitors, adress, tournamentSystem) VALUES ( @name, @startDate, @endDate,  @minCompetitors, @maxCompetitors, @adress, @tournamentSystem);";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@startDate", t.StartDate);
            command.Parameters.AddWithValue("@endDate", t.EndDate);
            command.Parameters.AddWithValue("@minCompetitors", t.MinCompetitors);
            command.Parameters.AddWithValue("@maxCompetitors", t.MaxCompetitors);
            command.Parameters.AddWithValue("@adress", t.Adress);
            command.Parameters.AddWithValue("@tournamentSystem", t.TournamentSystem);
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





        public void EditUser(Tournament t)
        {
            string sql = "UPDATE tournament SET name = @name, startDate = @startDate, endDate = @endDate, minCompetitors = @minCompetitors, maxCompetitors = @maxCompetitors, adress=@adress, tournamentSystem=@tournamentSystem WHERE id = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@startDate", t.StartDate);
            command.Parameters.AddWithValue("@endDate", t.EndDate);
            command.Parameters.AddWithValue("@minCompetitors", t.MinCompetitors);
            command.Parameters.AddWithValue("@maxCompetitors", t.MaxCompetitors);
            command.Parameters.AddWithValue("@adress", t.Adress);
            command.Parameters.AddWithValue("@tournamentSystem", t.TournamentSystem);
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
                if (conn!= null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
}