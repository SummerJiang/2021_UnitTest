using System.Collections.Generic;

namespace Tests
{
    public partial class Tests
    {
      
        public class TennisGame
        {
            private string FisrtPlayerName ;
            private string SecPlayerName ;
            private int FIrstPlayerScoreTimes;
            private int SecPlayerScoreTimes;
            public void TennisGameplayerName(string player1name,string plaryer2name )
            {
                this.FisrtPlayerName = player1name;
                this.SecPlayerName = plaryer2name;
            }

            public string Score()
            {
                var scoreLookup = new Dictionary<int, string>
                {
                    { 0,"Love"},
                    { 1,"Fifteen"},
                    { 2,"Thirty"},
                    { 3,"Forty"}
                };

                if (this.FIrstPlayerScoreTimes == SecPlayerScoreTimes)
                {
                    if (this.FIrstPlayerScoreTimes >= 3)
                    {
                        return "Deuce";
                    }
                    return $"{scoreLookup[FIrstPlayerScoreTimes] + " All"}";
                }
                if (this.FIrstPlayerScoreTimes >= 3 && this.SecPlayerScoreTimes >= 3)
                {
                    var advplayer = FIrstPlayerScoreTimes > SecPlayerScoreTimes ? FisrtPlayerName : SecPlayerName;
                    if (FIrstPlayerScoreTimes - SecPlayerScoreTimes == 1
                     || SecPlayerScoreTimes - FIrstPlayerScoreTimes == 1)
                    {
                        return advplayer + " Adv";
                    }
                    return advplayer + " Win";
                }
                
                return $"{ scoreLookup[FIrstPlayerScoreTimes] + " " + scoreLookup[SecPlayerScoreTimes]}";
            }

            public void FirstPlayerScore()
            {
                this.FIrstPlayerScoreTimes++;
            }

            public void SecPlayerScore()
            {
                this.SecPlayerScoreTimes++;
            }
        }
    }
}