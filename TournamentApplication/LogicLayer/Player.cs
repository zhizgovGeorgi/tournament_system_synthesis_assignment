using System.ComponentModel.DataAnnotations;

namespace LogicLayer
{
    public class Player
    {
        private User user;
        private int score;

        public User User { get { return this.user; } }


        public int Score { get { return this.score; } internal set { this.score = value; } }
        public Player(User user, int score)
        {
            this.user = user;
            this.score = score;
        }

    }
}