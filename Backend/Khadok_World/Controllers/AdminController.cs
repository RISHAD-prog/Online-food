using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Khadok_World.Controllers
{
    [EnableCors("*","*","*")]
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin")]
        public HttpResponseMessage GetUsers()
        {
            try
            {
                var data = RegistrationService.GetUsers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }

        }
        [HttpGet]
        [Route("api/admin/GetUser={id}")]
        public HttpResponseMessage GetUsers(int id)
        {
            try
            {
                var data = RegistrationService.GetUsers(id);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No data found");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, e.Message);
            }
        }
        [HttpPost]
        [Route("api/admin/EditUser={id}")]
        public HttpResponseMessage EditUsers(UsersDTO users, int id)
        {
            try
            {
                var data = RegistrationService.EditUserDeatails(users, id);
                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No data has been changed");
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, e.Message);
            }
        }
    }
}
