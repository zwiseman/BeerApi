using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeerApi.Interfaces;
using BeerApi.Services;
using BeerApi.Models;

namespace BeerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreweryController : ControllerBase
    {
        private readonly BreweryService _breweryService;

        public BreweryController(BreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        [HttpGet]
        public ActionResult<List<Brewery>> Get() =>
            _breweryService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBrewery")]
        public ActionResult<Brewery> Get(string id)
        {
            var brewery = _breweryService.Get(id);

            if (brewery == null)
            {
                return NotFound();
            }

            return brewery;
        }

        [HttpPost]
        public ActionResult<Brewery> Create(Brewery brewery)
        {
            _breweryService.Create(brewery);

            return CreatedAtRoute("GetBrewery", new { id = brewery.Id.ToString() }, brewery);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Brewery brewery)
        {
            var breweryId = _breweryService.Get(id);

            if (brewery == null)
            {
                return NotFound();
            }

            _breweryService.Update(id, breweryId);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var brewery = _breweryService.Get(id);

            if (brewery == null)
            {
                return NotFound();
            }

            _breweryService.Remove(brewery.Id);

            return NoContent();
        }
    }
}