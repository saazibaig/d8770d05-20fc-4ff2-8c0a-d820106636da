using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeekAd.BusinessModel;
using SeekAd.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SeekAd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DealController : ControllerBase
    {

        private readonly ILogger<DealController> _logger;
        private readonly IAdService _adService;

        public DealController(
            ILogger<DealController> logger,
            IAdService adService)
        {
            _logger = logger;
            _adService = adService;
        }

        [HttpPost("checkout")]
        public IActionResult CheckOut(Request request)
        {
            try
            {
                if (request == null)
                    return BadRequest();

                if (string.IsNullOrEmpty(request.CustomerName))
                    return BadRequest();

                if (!request.Ads.Any())
                    return BadRequest();

                var cost = _adService.CheckOut(request);

                return Ok (cost);
            }

            catch(Exception exception)
            {
                _logger.LogError(exception.Message);

                return this.StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
