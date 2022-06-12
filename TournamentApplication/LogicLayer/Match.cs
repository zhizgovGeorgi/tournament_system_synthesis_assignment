using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Match
    {
        private int roundNr;
        private int matchNr;
        private Player player1;
        private Player player2;
        private bool isComplete;

        public int Rounds
        {
            get { return this.roundNr; }
            private set
            {
                if (value < 0)
                {
                    throw new MyException("This should not be happening");
                }
                this.roundNr = value;
            }
        }
        public int Matches { get { return this.matchNr; }
            private set
            {
                if (value < 0)
                {
                    throw new MyException("This should not be happening");
                }
                this.matchNr = value;
            }
        }
        public bool IsComplete { get { return this.isComplete; } }

        public Player Player1
        {
            get { return this.player1; }
        }
        public Player Player2
        {
            get { return this.player2; }
            private set
            {
                if (value.User.Email == player1.User.Email)
                {
                    throw new MyException("A player cannot play against himself!");
                }
                this.player2 = value;
            }
        }

        public Match(int rounds, int matches, Player player1, Player player2, bool isComplete)
        {
            this.roundNr = rounds;
            this.matchNr = matches;
            this.player1 = player1;
            this.Player2 = player2;
            this.isComplete = isComplete;
        }


        public void SetScore(int score1, int score2)
        {
            if ((score1 < 21 && score2 < 21) || (score1 > 30 || score2 > 30) || (score1 == score2))
            {
                throw new MyException("Wrong setting of the score! Please check again before updating the match!");
            }
            if (score1 > 20 && score2 > 20 && score1 < 29 && score2 < 29 && Math.Max(score1, score2) - Math.Min(score1, score2) != 2)
            {
                throw new MyException("Score should after 20 points shold have 2 points difference");
            }
            player1.Score = score1;
            player2.Score = score2;
        }

        public override string ToString()
        {
            return $"{Player1.User.FName} {Player1.User.LName} vs. {Player2.User.FName} {Player2.User.LName} ";
        }
    }
}
