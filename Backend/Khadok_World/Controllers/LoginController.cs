using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Khadok_World.Controllers
{
    [EnableCors("*","*","*")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage Login (LoginDTO login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = LoginService.AuthUsers(login.Email, login.Password);
                    return Request.CreateResponse(HttpStatusCode.Accepted, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Please provide required data");
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        [Route("api/Logout/{TKey}")]
        public HttpResponseMessage Logout(string TKey)
        {
            try
            {
                if(TKey == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No token has been found");
                }
                var res =  LoginService.Logout(TKey);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, e.Message);
            }
        }
    }
}
