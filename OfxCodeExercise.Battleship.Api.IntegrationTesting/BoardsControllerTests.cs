using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using OfxCodeExercise.Battleship.Api.StateTracker.ViewModel;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OfxCodeExercise.Battleship.Api.IntegrationTesting
{
    public class BoardsControllerTests
    {
        private HttpClient _client;
        [OneTimeSetUp]
        public void SetupOnce()
        {
            var clientFactory = new CustomWebApplicationFactory();
            _client = clientFactory.CreateDefaultClient();
        }

        [Test]
        public async Task ShouldCreateABoard()
        {
            var request = new CreateBoardRequest()
            {
                Width = 10,
                Height = 15
            };
            var response = await _client.PostAsync($"/api/boards", Helpers.GetHttpRequestContent(request));
            response.EnsureSuccessStatusCode();
            var board = await Helpers.GetHttpResponseContent<BoardViewModel>(response);
            board.Should().NotBeNull();
            board.Id.Should().Be(1);
            board.Width.Should().Be(10);
            board.Height.Should().Be(15);
        }
        [Test]
        [Ignore("Fluent Validation is not working when running from WebApplicatonFactory")]
        public async Task BoardTooSmall()
        {
            var request = new CreateBoardRequest()
            {
                Width = 5,
                Height = 6
            };
            var response = await _client.PostAsync($"/api/boards", Helpers.GetHttpRequestContent(request));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            
        }
    }
}