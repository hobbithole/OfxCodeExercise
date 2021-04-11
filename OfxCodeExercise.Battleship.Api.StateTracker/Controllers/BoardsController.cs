using Microsoft.AspNetCore.Mvc;
using OfxCodeExercise.Battleship.Lib;
using OfxCodeExercise.Battleship.Api.StateTracker.ViewModel;
using Microsoft.AspNetCore.Http;
using System;

namespace OfxCodeExercise.Battleship.Api.StateTracker.Controllers
{
    /// <summary>
    /// battleship game board controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly IBattleshipProvider _battleshipProvider;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="battleshipProvider"></param>
        public BoardsController(IBattleshipProvider battleshipProvider)
        {
            _battleshipProvider = battleshipProvider;
        }
        /// <summary>
        /// Create a new Board for Battleship game.
        /// </summary>
        
        /// <param name="model">Create board view model.</param>
        /// <returns>The new Board view model.</returns>
        /// <response code="200">Returns new board json object</response>
        /// <response code="400">There was something wrong with the request.</response>
        /// <response code="500">An internal service error has occurred</response>
        [HttpPost]
        [Produces(typeof(CreateBoardRequest))]
        [ProducesResponseType(typeof(BoardViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<BoardViewModel> Create([FromBody] CreateBoardRequest model)
        {
            try
            {
                var board = _battleshipProvider.CreateBoard(model.ToBoard());
                return Ok(new BoardViewModel(board));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
