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
        private IRoundService _service;

        public RoundController(IRoundService roundService)
        {
            _service = roundService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            Round[] roundResult;
            try
            {
                roundResult = _service.GetAll().ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

            return Ok(roundResult);
        }

        [HttpGet("{id}", Name = "GetRound")]
        public ActionResult Get(int id)
        {
            Round roundResult;
            try
            {
                roundResult = _service.GetById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

            return Ok(roundResult);
        }

        public ActionResult Create([FromBody] Round round)
        {
            Round roundResult;
            try
            {
                if (round != null)
                {
                    roundResult = _service.AddWithWinner(round);
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

            return Ok(roundResult);
        }

    }
}