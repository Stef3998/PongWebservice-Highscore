using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongWebservice.Model
{
    public class Bruger
    {
        public int Id { get; set; }
        public string Brugernavn { get; set; }
        public int Highscore { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int AI_Wins { get; set; }
        public int AI_Loses { get; set; }
        public int Block_Highscore { get; set; }
        public int Block_Total_Points { get; set; }

        public Bruger(int id, string brugernavn, int highscore, int wins, int loses, int aiWins, int aiLoses, int blockHighscore, int blockTotalPoints)
        {
            Id = id;
            Brugernavn = brugernavn;
            Highscore = highscore;
            Wins = wins;
            Loses = loses;
            AI_Wins = aiWins;
            AI_Loses = aiLoses;
            Block_Highscore = blockHighscore;
            Block_Total_Points = blockTotalPoints;
        }

        public Bruger()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Brugernavn)}: {Brugernavn}, {nameof(Highscore)}: {Highscore}, {nameof(Wins)}: {Wins}, {nameof(Loses)}: {Loses}, {nameof(AI_Wins)}: {AI_Wins}, {nameof(AI_Loses)}: {AI_Loses}, {nameof(Block_Highscore)}: {Block_Highscore}, {nameof(Block_Total_Points)}: {Block_Total_Points}";
        }
    }
}
