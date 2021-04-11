using FluentAssertions;
using NUnit.Framework;
using OfxCodeExercise.Battleship.Api.StateTracker.ViewModel;
using OfxCodeExercise.Battleship.Lib;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace OfxCodeExercise.Battleship.Api.IntegrationTesting
{
    public class ShipsControllerTests
    {
        private HttpClient _client;
        [SetUp]
        public async Task Setup()
        {
            var clientFactory = new CustomWebApplicationFactory();
            _client = clientFactory.CreateDefaultClient();
            var request = new CreateBoardRequest()
            {
                Width = 10,
                Height = 15
            };
            var response = await _client.PostAsync($"/api/boards", Helpers.GetHttpRequestContent(request));
            response.EnsureSuccessStatusCode();
            await Helpers.GetHttpResponseContent<BoardViewModel>(response);
        }

        [Test]
        public async Task ShouldCreateAShip()
        {
            var createShipRequest = new CreateShipRequest 
            { 
                BoardId = 1, 
                StartAt = new Lib.Position { X = 0, Y = 0 }, 
                Length = 5, 
                Orientation = Lib.Orientation.Horizontal 
            };

            var createShipResponse = await _client.PostAsync($"/api/ships", Helpers.GetHttpRequestContent(createShipRequest));
            createShipResponse.EnsureSuccessStatusCode();
            var shipModel = await Helpers.GetHttpResponseContent<ShipViewModel>(createShipResponse);
            shipModel.Should().NotBeNull();
            shipModel.Id.Should().Be(1);
        }
        [Test]
        public async Task ShipTooBigForTheBoard()
        {
            var createShipRequest = new CreateShipRequest
            {
                BoardId = 1,
                StartAt = new Lib.Position { X = 1, Y = 1 },
                Length = 25,
                Orientation = Lib.Orientation.Horizontal
            };

            var createShipResponse = await _client.PostAsync($"/api/ships", Helpers.GetHttpRequestContent(createShipRequest));
            createShipResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Test]
        public async Task SecondShipCollideWithFirstOne()
        {
            var createShipRequest = new CreateShipRequest
            {
                BoardId = 1,
                StartAt = new Lib.Position { X = 0, Y = 0 },
                Length = 5,
                Orientation = Lib.Orientation.Horizontal
            };

            var createShipResponse = await _client.PostAsync($"/api/ships", Helpers.GetHttpRequestContent(createShipRequest));
            createShipResponse.EnsureSuccessStatusCode();

            createShipRequest = new CreateShipRequest
            {
                BoardId = 1,
                StartAt = new Lib.Position { X = 4, Y = 0 },
                Length = 5,
                Orientation = Lib.Orientation.Horizontal
            };

            createShipResponse = await _client.PostAsync($"/api/ships", Helpers.GetHttpRequestContent(createShipRequest));
            createShipResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Test]
        public async Task HitTheBattleship()
        {
            var createShipRequest = new CreateShipRequest
            {
                BoardId = 1,
                StartAt = new Lib.Position { X = 0, Y = 1 },
                Length = 5,
                Orientation = Lib.Orientation.Horizontal
            };

            var createShipResponse = await _client.PostAsync($"/api/ships", Helpers.GetHttpRequestContent(createShipRequest));
            createShipResponse.EnsureSuccessStatusCode();

            var attackRequest = new AttackRequest()
            {
                AttackAt = new Position()
                {
                    X = 1,
                    Y = 1
                },
                BoardId = 1
            };
            var attackResponse = await _client.PutAsync($"/api/ships/attack", Helpers.GetHttpRequestContent(attackRequest));
            attackResponse.EnsureSuccessStatusCode();
            var attackModel =  await Helpers.GetHttpResponseContent<AttackResponse>(attackResponse);
            attackModel.Should().NotBeNull();
            attackModel.IsHit.Should().BeTrue();
        }
        [Test]
        public async Task MissedTheBattleship()
        {
            var createShipRequest = new CreateShipRequest
            {
                BoardId = 1,
                StartAt = new Lib.Position { X = 0, Y = 1 },
                Length = 5,
                Orientation = Lib.Orientation.Horizontal
            };

            var createShipResponse = await _client.PostAsync($"/api/ships", Helpers.GetHttpRequestContent(createShipRequest));
            createShipResponse.EnsureSuccessStatusCode();

            var attackRequest = new AttackRequest()
            {
                AttackAt = new Position()
                {
                    X = 6,
                    Y = 6
                },
                BoardId = 1
            };
            var attackResponse = await _client.PutAsync($"/api/ships/attack", Helpers.GetHttpRequestContent(attackRequest));
            attackResponse.EnsureSuccessStatusCode();
            var attackModel = await Helpers.GetHttpResponseContent<AttackResponse>(attackResponse);
            attackModel.Should().NotBeNull();
            attackModel.IsHit.Should().BeFalse();
        }
    }
}