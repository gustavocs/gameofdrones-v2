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
            return Ok();
        }

        // PUT api/values/5
        public ActionResult Post([FromBody] GameConfig config)
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