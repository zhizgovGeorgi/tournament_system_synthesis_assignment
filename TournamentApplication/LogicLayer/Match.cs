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

        public Match(int rounds, int matches, Player player1 , Player player2)
        {
            this.rounds = rounds;
            this.matches = matches; 
            this.player1 = player1;
            this.player2 = player2;
        }

        public override string ToString()
        {
            return $"{player1} vs. {player2}";
        }
    }
}
