using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Match
    {
        private int rounds;
        private int matches;
        private Player player1;
        private Player player2;

        public int Rounds { get { return this.rounds; } }
        public int Matches { get { return this.matches; } }

        public Player Player1
        {
            get { return this.player1; }
            private set
            {
                if (player1== player2)
                {
                    throw new MyException("A player cannot play against himself!");
                }
                this.player1 = value;
            }
        }
        public Player Player2 { get { return this.player2; } }

        public Match(int rounds, int matches, Player player1 , Player player2)
        {
            this.rounds = rounds;
            this.matches = matches; 
            this.player1 = player1;
            this.player2 = player2;
        }

        public override string ToString()
        {
            return $"{Player1.User.FName} {Player1.User.LName} vs. {Player2.User.FName} {Player2.User.LName}";
        }
    }
}
