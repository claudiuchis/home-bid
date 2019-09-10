using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HomeBid.Services.Bidding.Models;
using HomeBid.Services.Bidding.Services;

namespace HomeBid.Services.Bidding.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private IBiddingService _biddingService;
        public PropertiesController(IBiddingService biddingService)
        {
            _biddingService = biddingService;
        }

        // GET api/v1/properties/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            return "value";
        }

        // POST api/v1/properties
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add([FromBody] BiddingProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedProperty = await _biddingService.AddBiddingProperty(property);
            return CreatedAtAction(nameof(GetById), new { id = addedProperty.Id }, addedProperty);
        }

    }
}
