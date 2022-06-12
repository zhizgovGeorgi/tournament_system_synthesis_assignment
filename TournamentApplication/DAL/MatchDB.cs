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
    public class MatchDB : IMatchDB<Match>
    {
        private MySqlConnection conn;
        public MatchDB()
        {
            conn = ConnectionDB.GetConnection();
        }

        public void AddMatch(List<Match> matches, Tournament t)
        {
            string sqlStatement = "";
            for (int i = 0; i < matches.Count; i++)
            {
                sqlStatement += $"INSERT INTO tournament_match ( tournamentId, roundNr, matchNr, player1,  score1, player2, score2, isCompleted) VALUES ( @tournamentId, @roundNr{i}, @matchNr{i}, @player1{i},  @score1{i}, @player2{i}, @score2{i}, isCompleted);";

            }
            sqlStatement += "UPDATE tournament SET status=@status WHERE id = @id;";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);
            command.Parameters.AddWithValue("@tournamentId", t.Id);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@status", Status.SCHEDULED.ToString());
            command.Parameters.AddWithValue($"@isCompleted", false);

            for (int i = 0; i < matches.Count; i++)
            {
                command.Parameters.AddWithValue($"@roundNr{i}", matches[i].Rounds);
                command.Parameters.AddWithValue($"@matchNr{i}", matches[i].Matches);
                command.Parameters.AddWithValue($"@player1{i}", matches[i].Player1.User.Id);
                command.Parameters.AddWithValue($"@score1{i}", matches[i].Player1.Score);
                command.Parameters.AddWithValue($"@player2{i}", matches[i].Player2.User.Id);
                command.Parameters.AddWithValue($"@score2{i}", matches[i].Player2.Score);

            }
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

        public void GetMatches(Tournament t)
        {
            string sqlStatement = "SELECT * FROM tournament_match WHERE tournamentId = @tournamentId";
            MySqlCommand command = new MySqlCommand(sqlStatement, conn);
            List<Match> matches = new List<Match>();
            UserDB userDB = new UserDB();

            command.Parameters.AddWithValue("@tournamentId", t.Id);

            try
            {
                MySqlDataReader databaseReader;

                conn.Open();
                databaseReader = command.ExecuteReader();
                Match match;


                while (databaseReader.Read())
                {
                    Player player1 = new Player(userDB.ReadUser(databaseReader.GetInt32("player1")), databaseReader.GetInt32("score1"));
                    Player player2 = new Player(userDB.ReadUser(databaseReader.GetInt32("player2")), databaseReader.GetInt32("score2"));
                    match = new Match(databaseReader.GetInt32("roundNr"), databaseReader.GetInt32("matchNr"), player1, player2, databaseReader.GetBoolean("isCompleted"));
                    matches.Add(match);
                }
                t.AssignMatches(matches);
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

        public void SetScore(Match m, Tournament t)
        {
            string sql = "UPDATE tournament_match SET score1 = @score1, score2 = @score2, isCompleted=@isCompleted WHERE tournamentId = @tournamentId and roundNr=@roundNr and matchNr=@matchNr";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tournamentId", t.Id);
            cmd.Parameters.AddWithValue("@roundNr", m.Rounds);
            cmd.Parameters.AddWithValue("@matchNr", m.Matches);
            cmd.Parameters.AddWithValue("@score1", m.Player1.Score);
            cmd.Parameters.AddWithValue("@score2", m.Player2.Score);
            cmd.Parameters.AddWithValue("@isCompleted", true);
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
