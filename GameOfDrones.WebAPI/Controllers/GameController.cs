using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameOfDrones.Services;
using GameOfDrones.Models;

namespace GameOfDrones.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        private IGameService _service;
        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<Game> games = _service.GetAll();
                return Ok(games);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            try
            {
                Game game = _service.GetResults(id);
                return Ok(game);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        public ActionResult Create([FromBody] Game game)
        {
            try
            {
                if (game != null)
                {
                    var gameResult = _service.Add(game);
                    return Ok(gameResult);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}