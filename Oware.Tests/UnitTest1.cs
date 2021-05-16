using NUnit.Framework;

namespace Oware.Tests
{
    public class Tests
    {   
        public class MockScoreHouse : IScoreHouse
        {   
            public void AddSeed(Seed seed)
            {
            }

            public int GetCount()
            {
                return 1; //throw new System.NotImplementedException();
            }

            public void Reset()
            {
                throw new System.NotImplementedException();
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //ARRANGE
            House h = new House(0, 0);
            Seed seed = new Seed();
            h.AddSeedInPot(seed);
            //ACT
            h.ResetHouse(); 
            //ASSERT
            Assert.AreEqual(4, h.GetCount(), "Resetting the house should restore the House to 4 seeds in the pot");
        }

        [Test]
        public void Test2()
        {   
            //ARRANGE
            MockScoreHouse oneScore = new MockScoreHouse();
            MockScoreHouse twoScore = new MockScoreHouse();
            Player one = new Player("Player 1", oneScore);
            Player two = new Player("Player 2", twoScore);
            Board b = new Board(one, two);
            //ACT          
            Seed seed = new Seed();
            one.AddSeedToScoreHouse(seed);
            //ASSERT
            Assert.AreEqual(1,one.GetScore(),"The score should be one");
        }
    }
}