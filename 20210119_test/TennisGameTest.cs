using NUnit.Framework;

namespace Tests
{
    public partial class Tests
    {
        [SetUp]
        public void Setup()
        {
            _tennisGame = new TennisGame();
            _tennisGame.TennisGameplayerName("Summer", "CC");
        }
        private TennisGame _tennisGame;

        [Test]
        public void Game_Start_OutPute_LoveAll()
        {
            FinalScore("Love All");
        }

        [Test]
        public void Fifteen_Love()
        {
            GivenFirstPlayerScoreTime(1);
            FinalScore("Fifteen Love");
        }

        [Test]
        public void Thirty_Love()
        {
            GivenFirstPlayerScoreTime(2);
            FinalScore("Thirty Love");
        }

        [Test]
        public void Forty_Love()
        {
            GivenFirstPlayerScoreTime(3);
            FinalScore("Forty Love");
        }


        [Test]
        public void Fifteen_All()
        {
            GivenFirstPlayerScoreTime(1);
            GivenSecPlayerScoreTime(1);
            FinalScore("Fifteen All");
        }


        [Test]
        public void Deuce()
        {
            GivenFirstPlayerScoreTime(3);
            GivenSecPlayerScoreTime(3);
            FinalScore("Deuce");
        }

        [Test]
        public void Summer_Adv()
        {
            GivenFirstPlayerScoreTime(4);
            GivenSecPlayerScoreTime(3);
            FinalScore("Summer Adv");
        }

        [Test]
        public void Summer_Win()
        {
            GivenFirstPlayerScoreTime(5);
            GivenSecPlayerScoreTime(3);
            FinalScore("Summer Win");
        }

        [Test]
        public void Thirty_Forty()
        {
            GivenFirstPlayerScoreTime(2);
            GivenSecPlayerScoreTime(3);
            FinalScore("Thirty Forty");
        }

        private void FinalScore(string expect)
        {
            Assert.AreEqual(expect, _tennisGame.Score());
        }

        private void GivenFirstPlayerScoreTime(int Times)
        {
            for (var i = 0; i < Times; i++)
            {
                _tennisGame.FirstPlayerScore();
            }
        }

        private void GivenSecPlayerScoreTime(int Times)
        {
            for (var i = 0; i < Times; i++)
            {
                _tennisGame.SecPlayerScore();
            }
        }
    }

   
}