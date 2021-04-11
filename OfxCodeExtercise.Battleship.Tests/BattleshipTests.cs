using FluentAssertions;
using NUnit.Framework;
using OfxCodeExercise.Battleship.Lib;
using System.Linq;

namespace OfxCodeExtercise.Battleship.Tests
{
    public class BattleshipTests
    {
        [Test]
        public void ShouldCreateCorrectShipParts_Horizontal()
        {
            var startPosition = new Position() { X = 1, Y = 1 };
            var battleship = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Horizontal, 3);
            battleship.ShipParts.Count.Should().Be(3);
            var positions = battleship.ShipParts.Select(s => s.Position).ToList();
            positions[0].Should().Be(new Position { X = 1, Y = 1 });
            positions[1].Should().Be(new Position { X = 2, Y = 1 });
            positions[2].Should().Be(new Position { X = 3, Y = 1 });
        }
        [Test]
        public void ShouldCreateCorrectShipParts_Vertical()
        {
            var startPosition = new Position() { X = 0, Y = 0 };
            var battleship = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Vertical, 5);
            battleship.ShipParts.Count.Should().Be(5);
            var positions = battleship.ShipParts.Select(s => s.Position).ToList();
            positions[0].Should().Be(new Position { X = 0, Y = 0 });
            positions[1].Should().Be(new Position { X = 0, Y = 1 });
            positions[2].Should().Be(new Position { X = 0, Y = 2 });
            positions[3].Should().Be(new Position { X = 0, Y = 3 });
            positions[4].Should().Be(new Position { X = 0, Y = 4 });
        }
        [Test]
        public void AttackedAndMissed()
        {
            var startPosition = new Position() { X = 0, Y = 0 };
            var battleship = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Vertical, 5);
            battleship.Attacked(new Position { X = 1, Y = 1}).Should().BeFalse();
        }
        [Test]
        public void AttackedAndBeingHit()
        {
            var startPosition = new Position() { X = 1, Y = 1 };
            var battleship = new OfxCodeExercise.Battleship.Lib.Battleship(1, startPosition, Orientation.Vertical, 5);
            battleship.Attacked(new Position { X = 1, Y = 5 }).Should().BeTrue();
        }
    }
}