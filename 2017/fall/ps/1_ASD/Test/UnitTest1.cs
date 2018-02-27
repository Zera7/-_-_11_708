using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASD_1;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        static FootballClub a = new FootballClub("1", 1, 1, 1, 1, 1);
        static FootballClub b = new FootballClub("2", 10, 1, 1, 10, 1);
        static FootballClub c = new FootballClub("10", 10, 1, 1, 10, 1);

        [TestMethod]
        public void CompareByScoreTest()
        {
            Assert.AreEqual(-1, Program.CompareByScore(a, b));
            Assert.AreEqual(1, Program.CompareByScore(b, a));
            Assert.AreEqual(0, Program.CompareByScore(a, a));
        }

        [TestMethod]
        public void CompareByGoalsScored()
        {
            Assert.AreEqual(-1, Program.CompareByScore(a, b));
            Assert.AreEqual(1, Program.CompareByScore(b, a));
            Assert.AreEqual(0, Program.CompareByScore(a, a));
        }

        [TestMethod]
        public void IndexTest()
        {
            FootballList list = new FootballList(a, b);
            Assert.AreEqual(1, list[0].Wins);
            Assert.AreEqual(1, list[0].Draws);
            Assert.AreEqual(1, list[0].Losses);
            Assert.AreEqual(1, list[0].GoalsScored);
            Assert.AreEqual(1, list[0].GoalsConceded);
        }

        [TestMethod]
        public void ReadClubsTest()
        {
            FootballList list = new FootballList();
            list.ReadClubs("test.txt");
            Assert.AreEqual("1", list[0].Name);
            Assert.AreEqual("2", list[1].Name);
            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void UpdateClubsTest()
        {
            FootballList list = new FootballList();
            list.ReadClubs("FirstTour.txt");
            list.UpdateClubs("UpdateClubs.txt");
            Assert.AreEqual(12, list[0].GamesPlayed);
            Assert.AreEqual(6, list[1].GamesPlayed);
            Assert.AreEqual(4, list[2].GamesPlayed);
            Assert.AreEqual(644, list[3].GamesPlayed);
            Assert.AreEqual(4, list.Count);
        }

        [TestMethod]
        public void LexicographicalCompareTest()
        {
            FootballList list = new FootballList(c, b, a);
            list.Sort();
            Assert.AreEqual("1", list[0].Name);
            Assert.AreEqual("10", list[1].Name);
            Assert.AreEqual("2", list[2].Name);
        }

        [TestMethod]
        public void GetMinDrawsClubTest()
        {
            FootballList list = new FootballList();
            list.ReadClubs("FirstTour.txt");
            Assert.AreEqual("poe", list.GetMinDrawsClub().Name);
        }

        [TestMethod]
        public void ScoreSortTest()
        {
            FootballList list = new FootballList();
            list.ReadClubs("FirstTour.txt");
            list.Sort(Program.CompareByScore);
            Assert.AreEqual("dag", list[0].Name);
            Assert.AreEqual("poe", list[1].Name);
            Assert.AreEqual("bar", list[2].Name);
            Assert.AreEqual("taj", list[3].Name);
        }

        [TestMethod]
        public void GetNewListSortedByScoredGoalsTest()
        {
            FootballList list = new FootballList();
            list.ReadClubs("FirstTour.txt");
            FootballList newList = list.GetSortedFootballList(Program.CompareByGoalsScored);
            Assert.AreEqual("dag", newList[0].Name);
            Assert.AreEqual("taj", newList[1].Name);
            Assert.AreEqual("poe", newList[2].Name);
            Assert.AreEqual(list.Count, newList.Count);
        }

        [TestMethod]
        public void GetMaxDifferenceScoredAndConcededClubTest()
        {
            FootballList list = new FootballList();
            list.ReadClubs("FirstTour.txt");
            Assert.AreEqual("bar", list.GetMaxDifferenceScoredAndConcededClub().Name);
        }
    }
}
