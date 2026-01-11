using HelloWorldApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        public ResponseModel Get()
        {
            return new ResponseModel() 
            {
                HttpStatus = 200,
                Message = "YARRAK ZORLAMA SIKTIR GIT"
            };
        }
    }
}
