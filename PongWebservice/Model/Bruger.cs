using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongWebservice.Model
{
    public class Bruger
    {
        public string Brugernavn { get; set; }
        public int Highscore { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Winstreak { get; set; }

        public Bruger(string brugernavn, int highscore, int wins, int loses, int winstreak)
        {
            Brugernavn = brugernavn;
            Highscore = highscore;
            Wins = wins;
            Loses = loses;
            Winstreak = winstreak;
        }

        public Bruger()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(Brugernavn)}: {Brugernavn}, {nameof(Highscore)}: {Highscore}, {nameof(Wins)}: {Wins}, {nameof(Loses)}: {Loses}, {nameof(Winstreak)}: {Winstreak}";
        }
    }
}
