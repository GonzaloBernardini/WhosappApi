using Microsoft.AspNetCore.Mvc;
using Whosapp.Entities.Authentication;
using Whosapp.Service;
using Whosapp.UOWork;

namespace Whosapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IUnitOfWork _uOw;
        public UserController(IUserService userService, IUnitOfWork uOw)
        {
            this._userService = userService;
            this._uOw = uOw;
        }

        [HttpPost]
        public ActionResult Login([FromBody] AuthenticateRequest userReq)
        {
            var userResp = _userService.Login(userReq.Email, userReq.Password);

            //if user !is.authenticated return unauthorized

            if(userResp == null)
            {
                return Unauthorized();
            }

            var token = _userService.GetToken(userResp);

            return Ok(new
            {
                token = token,
                user = userResp
            });
        }


        [HttpPost("RegisterUser")]
        public ActionResult RegisterUser([FromBody] AuthenticateRequest userReq)
        {
            if(_uOw.UserRepository.ExisteUsuario(userReq.Email.ToLower()))
            {
                return BadRequest("There is already an account associated with this email");
            }
            AuthenticateResponse userResp = _userService.RegisterUser(userReq, userReq.Password);

            return Ok(userResp);
        }

        [HttpPost("RegisterAdmin")]
        public ActionResult RegisterAdmin([FromBody] AuthenticateRequest userReq)
        {
            if (_uOw.UserRepository.ExisteUsuario(userReq.Email.ToLower()))
            {
                return BadRequest("There is already an account associated with this email");
            }
            AuthenticateResponse userResp = _userService.RegisterAdmin(userReq, userReq.Password);

            return Ok(userResp);
        }
    }
}
