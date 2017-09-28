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
    [Route("api/Round")]
    public class RoundController : Controller
    {
        private IRoundService _roundService;

        public RoundController(IRoundService roundService)
        {
            _roundService = roundService;
        }

        public ActionResult Get()
        {
            return Ok(_roundService.GetAll());
        }

        public ActionResult Get(int id)
        {
            return Ok(_roundService.GetById(id));
        }

        public ActionResult Post([FromBody] Round round)
        {
            return Ok(_roundService.AddWithWinner(round));    
        }

    }
}