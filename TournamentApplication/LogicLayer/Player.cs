namespace LogicLayer
{
    public class Player
    {
        private User user;
        private int score;

        public User User { get; set; }
        public int Score { get; set; }
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