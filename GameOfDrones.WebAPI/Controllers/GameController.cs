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
            Game[] games;
            try
            {
                games = _service.GetAll(g => g.Players, g => g.Rounds).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
            return Ok(games);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            Game game;
            try
            {
                game = _service.GetResults(id);
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
            return Ok(game);
        }

        public ActionResult Create([FromBody] Game game)
        {
            Game gameResult;
            try
            {
                if (game != null)
                {
                    gameResult = _service.Add(game);
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

            return Ok(gameResult);
        }
    }
}