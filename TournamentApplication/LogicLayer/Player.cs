using System.ComponentModel.DataAnnotations;

namespace LogicLayer
{
    public class Player
    {
        private User user;
        private int score;

        public User User { get { return this.user; } }


        public int Score
        {
            get { return this.score; }
            internal set
            {
                if (value < 0)
                {
                    throw new MyException("Score cannot be a negative number!");
                }
                this.score = value;
            }
        }
        public Player(User user, int score)
        {
            this.user = user;
            this.Score = score;
        }

    }
}