using FluentAssertions;
using NUnit.Framework;
using OfxCodeExercise.Battleship.Lib;
using OfxCodeExercise.Battleship.Lib.Exceptions;

namespace OfxCodeExtercise.Battleship.Tests
{
    public class BattleshipProviderTests
    {
        private IBattleshipProvider _provider;
        [SetUp]
        public void Setup()
        {
            _provider = new BattleshipProvider();
        }

        [Test]
        public void ShouldCreateTwoBoards()
        {
            var board1 = _provider.CreateBoard(new Board { Height = 10, Width = 20 });
            board1.Id.Should().Be(1);
            board1.Height.Should().Be(10);
            board1.Width.Should().Be(20);
            board1.Ships.Count.Should().Be(0);
            var board2 = _provider.CreateBoard(new Board { Height = 100, Width = 200 });
            board2.Id.Should().Be(2);
            board2.Height.Should().Be(100);
            board2.Width.Should().Be(200);
            board2.Ships.Count.Should().Be(0);
        }
        [Test]
        public void ShouldAddTwoShipsToTheBoard()
        {
            var board = _provider.CreateBoard(new Board { Height = 10, Width = 20 });
            board.Id.Should().Be(1);
            var startPosition1 = new Position() { X = 0, Y = 0 };
            var battleship1 = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition1, Orientation.Horizontal, 5);
            board.AddBattleship(battleship1);
            board.Ships.Count.Should().Be(1);
            var startPosition2 = new Position() { X = 5, Y = 0 };
            var battleship2 = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition2, Orientation.Horizontal, 5);
            board.AddBattleship(battleship2);
            board.Ships.Count.Should().Be(2);
        }
        [Test]
        public void ShipTooBigToAddToTheBoard()
        {
            var board = _provider.CreateBoard(new Board { Height = 10, Width = 20 });
            board.Id.Should().Be(1);
            var startPosition1 = new Position() { X = 0, Y = 0 };
            var battleship1 = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition1, Orientation.Horizontal, 21);
            Assert.Throws<InvalidRequestException>( ()=> board.AddBattleship(battleship1));
            board.Ships.Count.Should().Be(0);
        }
        [Test]
        public void SecondShipCollideWIthTheFirst()
        {
            var board = _provider.CreateBoard(new Board { Height = 10, Width = 20 });
            board.Id.Should().Be(1);
            var startPosition1 = new Position() { X = 1, Y = 1 };
            var battleship1 = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition1, Orientation.Horizontal, 5);
            board.AddBattleship(battleship1);
            board.Ships.Count.Should().Be(1);
            var startPosition2 = new Position() { X = 2, Y = 0 };
            var battleship2 = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition1, Orientation.Vertical, 5);
            Assert.Throws<ShipCollisionException>(() => board.AddBattleship(battleship2));
            board.Ships.Count.Should().Be(1);
        }
    }
}