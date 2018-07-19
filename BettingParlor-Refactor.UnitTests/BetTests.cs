using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BettingParlor_Refactor.UnitTests
{
    /// <summary>
    /// Contains unit test related to all <see cref="Bet"/> derivatives included in project.
    /// </summary>
    /// <remarks>
    /// Unit tests are related to all kind of bets included in project.
    /// </remarks>
    [TestClass]
    public class BetTests
    {
        /// <summary>
        /// Test whether standard bet pays out proper amount.
        /// </summary>
        [TestMethod]
        public void PayOutTheAmountWon_StandardBetIsPlacedOnDogWichWon_DoubleOfPlacedValueIsReturned()
        {
            //Arrange
            var betFactory = new BetFactory();
            var betSort = BetFactory.BetSort.standartBet;
            var expectedWinning = 20M;
            var amountWhichIsPlaced = 10M;
            var dogOnWichBetIsPlaced = 1;
            var dogWhichWonTheRace = 1;

            //Action
            var standardBet = betFactory.CreateBet(betSort,amountWhichIsPlaced,dogOnWichBetIsPlaced);
            var actualWinning = standardBet.PayOutTheAmountWon(dogWhichWonTheRace);

            //Assert
            Assert.AreEqual(expectedWinning, actualWinning);
        }

        /// <summary>
        /// Test whether standard bet behaves properly when bet is placed on wrong dog.
        /// </summary>
        [TestMethod]
        public void PayOutTheAmountWon_StandardBetIsPlacedOnDogWichLost_ZeroIsReturned()
        {
            //Arrange
            var betFactory = new BetFactory();
            var betSort = BetFactory.BetSort.standartBet;
            var expectedWinning = 0M;
            var amountWhichIsPlaced = 10M;
            var dogOnWichBetIsPlaced = 1;
            var dogWhichWonTheRace = 2;

            //Action
            var standardBet = betFactory.CreateBet(betSort, amountWhichIsPlaced, dogOnWichBetIsPlaced);
            var actualWinning = standardBet.PayOutTheAmountWon(dogWhichWonTheRace);

            //Assert
            Assert.AreEqual(expectedWinning, actualWinning);
        }

        /// <summary>
        /// Test whether handicap bet pays out proper amount.
        /// </summary>
        [TestMethod]
        public void PayOutTheAmountWon_HandicapIsPlacedOnDogWichWon_PlacedValueMultupliedByOnePointFive()
        {
            //Arrange
            var betFactory = new BetFactory();
            var betSort = BetFactory.BetSort.handicapBet;
            var expectedWinning = 30M;
            var amountWhichIsPlaced = 20M;
            var dogOnWichBetIsPlaced = 1;
            var dogWhichWonTheRace = 1;

            //Action
            var handicapBet = betFactory.CreateBet(betSort, amountWhichIsPlaced, dogOnWichBetIsPlaced);
            var actualWinning = handicapBet.PayOutTheAmountWon(dogWhichWonTheRace);

            //Assert
            Assert.AreEqual(expectedWinning, actualWinning);
        }

        /// <summary>
        /// Test whether handicap bet behaves properly when bet is placed on wrong dog.
        /// </summary>
        [TestMethod]
        public void PayOutTheAmountWon_HandicapBetIsPlacedOnDogWichLost_ZeroIsReturned()
        {
            //Arrange
            var betFactory = new BetFactory();
            var betSort = BetFactory.BetSort.handicapBet;
            var expectedWinning = 0M;
            var amountWhichIsPlaced = 20M;
            var dogOnWichBetIsPlaced = 1;
            var dogWhichWonTheRace = 2;

            //Action
            var handicapBet = betFactory.CreateBet(betSort, amountWhichIsPlaced, dogOnWichBetIsPlaced);
            var actualWinning = handicapBet.PayOutTheAmountWon(dogWhichWonTheRace);

            //Assert
            Assert.AreEqual(expectedWinning, actualWinning);
        }
    }
}
