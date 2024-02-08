using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Interface_Service;
using Subscriber.CORE.Response;

namespace Subscriber.WebWpi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightWatchersController : ControllerBase
    {
        IWeightWatchersService _weightWatchersService;

        public WeightWatchersController(IWeightWatchersService weightWatchersService)
        {
            _weightWatchersService = weightWatchersService;
        }
        [HttpPost]
        public async Task<ActionResult<BaseResponseGeneral<bool>> >Register([FromBody] SubscriberDTO subscriberDTO)
        {
            var response= await _weightWatchersService.Register(subscriberDTO);
            if (response.Succed == false)
            {
                return NotFound(response);
            }
            return Ok(response);
          
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<BaseResponseGeneral<CardDTO>>> Login([FromBody] LoginDTO login)
        {
            var response = await _weightWatchersService.Login(login.Password, login.Email);
            if (response.Succed == false)
            {
                return NotFound(response);
            }
            return Ok(response);

        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseGeneral<GetCardIdResponse>>> GetCardById( int id)
        {
            var response = await _weightWatchersService.GetCardDetails(id);
            if (response.Succed == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
         
    }
}
