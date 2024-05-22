using FileConverter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FileConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabController : ControllerBase
    {
        private readonly ICsvService _csvService;
        private readonly ITripService _tripService;

        public CabController(ICsvService csvService, ITripService tripService)
        {
            _csvService = csvService;
            _tripService = tripService;
        }

        [HttpPost("SetupData")]
        public async Task<ActionResult> SetupData()
        {
            var tripsData = _csvService.ReadCabData();
            await _tripService.CreateAsync(tripsData);

            return Ok();
        }


        [HttpGet("Get")]
        public ActionResult Get(
            [FromQuery] int? locationId,
            [FromQuery] bool orderByDistance = false,
            [FromQuery] bool orderByTime = false)
        {
            var trips = _tripService.Get(locationId, orderByDistance, orderByTime);

            return Ok(trips);
        }

        [HttpGet("Get/Duplicates")]
        public async Task<ActionResult> GetDuplicates()
        {
            var trips = _tripService.GetDuplicates();
            await _tripService.DeleteAsync(trips);
            _csvService.WriteCabData(trips);

            return Ok();
        }

        [HttpGet("Get/LocationIdByHighestAverageTipAmount")]
        public async Task<ActionResult> GetLocationIdByHighestAverageTipAmount()
        {
            var locationId = await _tripService.GetHighestTipAmountByPULocationIdAsync();

            return Ok(locationId);
        }
    }
}
