using Microsoft.AspNetCore.Mvc;
using Store.Business.Interface;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult Index() 
        {
            try
            {
                return Ok(_cinemaBusiness.GetCinemas());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw e;
            }
        }        
    }
}
