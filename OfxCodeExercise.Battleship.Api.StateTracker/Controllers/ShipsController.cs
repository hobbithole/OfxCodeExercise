using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfxCodeExercise.Battleship.Api.StateTracker.ViewModel;
using OfxCodeExercise.Battleship.Lib;
using OfxCodeExercise.Battleship.Lib.Exceptions;
using System;

namespace OfxCodeExercise.Battleship.Api.StateTracker.Controllers
{
    /// <summary>
    /// Battleship controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ShipsController : ControllerBase
    {
        private readonly IBattleshipProvider _battleshipProvider;
        /// <summary>
        /// Ships Controller constructor
        /// </summary>
        /// <param name="battleshipProvider"></param>
        public ShipsController(IBattleshipProvider battleshipProvider)
        {
            _battleshipProvider = battleshipProvider;
        }
        /// <summary>
        /// Create a new Ship on an existing Board.
        /// </summary>
        /// <param name="request">Specify the Board, the starting position, orientation and length of the new ship.</param>
        /// <returns>The new Ship view model</returns>
        /// <response code="200">Returns a json object containing new Ship view model.</response>
        /// <response code="400">invalid request</response>
        /// <response code="404">The board could not be found.</response>
        /// <response code="500">An internal service error has occurred</response>
        [HttpPost]
        [Produces(typeof(CreateShipRequest))]
        [ProducesResponseType(typeof(ShipViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<ShipViewModel> Create([FromBody] CreateShipRequest request)
        {
            try
            {
                var ship = _battleshipProvider.AddShipToBoard(request.BoardId, request.ToBattleship());
                return Ok(new ShipViewModel(ship));
            }
            catch(InvalidRequestException iex)
            {
                return BadRequest(new { error = iex.Message });
            }
            catch(ShipCollisionException sx)
            {
                return BadRequest( new {error = sx.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
            
        }

        /// <summary>
        /// Attack a battleship on an existing Board.
        /// </summary>
        /// <param name="model">Specify the Board and attack point on the board.</param>
        /// <returns>the board, the attack location and isHit boolean</returns>
        /// <response code="200">Returns a json object containing the results of the Attack.</response>
        /// <response code="400">Invalid request parameters</response>
        /// <response code="404">The board could not be found.</response>
        /// <response code="500">An internal service error has occurred</response>
        [HttpPut("attack")]
        [Produces(typeof(bool))]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<AttackResponse> Attack(AttackRequest model)
        {
            var isHit = _battleshipProvider.Attack(model.BoardId, model.AttackAt);

            return Ok(new AttackResponse
            {
                BoardId = model.BoardId,
                AttackAt = model.AttackAt,
                IsHit = isHit
            }) ;
        }
    }
}
