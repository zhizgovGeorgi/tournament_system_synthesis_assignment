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
            private set
            {
                if (score < 0)
                {
                    throw new MyException("The score cannot be a negative number!");
                }
                else if (score > 30)
                {
                    throw new MyException("The score cannot be a more than 30!");
                }
                this.score = value;
            }
        }
        public Player(User user, int score)
        {
            this.user = user;
            this.score = score;
        }

        public Player()
        {

        }
    }
}