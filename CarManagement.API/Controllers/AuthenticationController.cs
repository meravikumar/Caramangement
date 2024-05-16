using CarManagement.Business.IServices;
using CarManagement.Core.ViewModels.LoginToken;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace CarManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthService _userAuthService;
        public AuthenticationController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }
        [HttpPost]
        public IActionResult Authentication([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                var result = _userAuthService.Login(loginViewModel);
                if (result.StatusCode == (int)HttpStatusCode.BadRequest)
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
