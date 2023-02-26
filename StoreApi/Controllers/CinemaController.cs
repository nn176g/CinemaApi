using Microsoft.AspNetCore.Mvc;
using Store.Business.Interface;
using Store.Data.Models;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : Controller
    {
        private readonly ILogger<CinemaController> _logger;
        private readonly ICinemaBusiness _cinemaBusiness;

        public CinemaController(ILogger<CinemaController> logger, ICinemaBusiness cinemaBusiness)
        {
            _logger = logger;
            _cinemaBusiness = cinemaBusiness;
        }
        //[HttpGet(Name = "GetCinemas")]
        [HttpGet]
        [Route("Index")]
        public IActionResult Index(int ? id) 
        {
            try
            {
                return Ok(_cinemaBusiness.GetCinemas(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpGet]
        [Route("GetCinemaAviables")]
        public IActionResult GetCinemaAviables()
        {
            try
            {
                return Ok(_cinemaBusiness.GetCinemaAviables());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpGet]
        [Route("GetCinemaByHours")]
        public IActionResult GetCinemasByHours(int starTime, int endTime) {
            try
            {
                return Ok(_cinemaBusiness.GetCinemasByHours(starTime, endTime));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }

        [HttpPost]
        [Route("InsertCinema")]
        public async Task<IActionResult> InsertCinema(Cinemas model)
        {
            try
            {
                return Ok(await _cinemaBusiness.Insert(model));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }
    }
}
