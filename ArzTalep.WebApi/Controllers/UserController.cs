using Aware.Manager;
using Aware.Model;
using Aware.Util.Constants;
using Aware.Util.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Aware.BL.Model;

namespace ArzTalep.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IEncryptManager _encryptManager;

        public UserController(IUserManager userManager, IEncryptManager encryptManager)
        {
            _userManager = userManager;
            _encryptManager = encryptManager;
        }

        public ActionResult<string> Index(string returnUrl)
        {
            //if (_sessionHelper.CurrentUserID > 0)
            //{
            //    returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
            //    return Redirect(returnUrl);
            //}
            return "not logged!";
        }


        [HttpPost("login")]
        public ActionResult<OperationResult<SessionDataModel>> Login(UserRequestDto user)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.Login(user.username, user.password);
                //if (result.Ok)
                //{


                //    //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                //    //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, invite.Id.ToString()));

                //    //var principal = new ClaimsPrincipal(identity);
                //    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //}
                return result;
            }
            return OperationResult<SessionDataModel>.Error(ResultCodes.Error.Login.InvalidUsernamePassword);
        }
    }

   
}

public class UserRequestDto
{
    public string username { get; set; }
    public string password { get; set; }
}