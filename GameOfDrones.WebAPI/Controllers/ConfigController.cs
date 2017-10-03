using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameOfDrones.Services;
using System.Net;
using GameOfDrones.Models;

namespace GameOfDrones.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Config")]
    public class ConfigController : Controller
    {
        private IConfigService _service;
        public ConfigController(IConfigService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            GameConfig configResult;
            try
            {
                configResult = _service.GetConfig();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
            return Ok(configResult);
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Update([FromBody] GameConfig config)
        {
            try
            {
                _service.UpdateConfig(config);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e);
            }
            return Ok();
        }
    }
}