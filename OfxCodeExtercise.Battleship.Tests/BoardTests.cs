using FluentAssertions;
using NUnit.Framework;
using OfxCodeExercise.Battleship.Lib;
using OfxCodeExercise.Battleship.Lib.Exceptions;
using System.Linq;

namespace OfxCodeExtercise.Battleship.Tests
{
    public class BoardTests
    {
        private Board _board;
        [SetUp]
        public void Setup()
        {
            _board = new Board { Id = 1, Height = 10, Width = 10 };
        }

        [Test]
        public void ShouldAddAShipSuccessfully()
        {
            var startPosition = new Position() { X = 1, Y = 1 };
            var battleship = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Horizontal, 3);
            var ship = _board.AddBattleship(battleship);
            ship.Id.Should().Be(1);
        }
        [Test]
        public void ShipToBigToFitIntoBoard()
        {
            var startPosition = new Position() { X = 0, Y = 0 };
            var battleship = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Horizontal, 11);
            Assert.Throws<InvalidRequestException>(()=> _board.AddBattleship(battleship));
        }
        [Test]
        public void SecondShipCollideWithFirstShip()
        {
            var startPosition = new Position() { X = 0, Y = 0 };
            var battleship1 = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Horizontal, 5);
            var battleship2 = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Vertical, 5);
            var ship = _board.AddBattleship(battleship1);
            ship.Id.Should().Be(1);
            Assert.Throws<ShipCollisionException>(() => _board.AddBattleship(battleship2));
        }
    }
}