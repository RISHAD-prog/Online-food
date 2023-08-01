using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Khadok_World.Controllers
{
    [EnableCors("*", "*", "*")]
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("api/registration/addUser")]
        public HttpResponseMessage Registration(RegistrationDTO registration)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = RegistrationService.Add(registration);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
