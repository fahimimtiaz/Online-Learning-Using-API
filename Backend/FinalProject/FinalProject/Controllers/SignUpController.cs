using FinalProject.Models;
using FinalProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class SignUpController : ApiController
    {
        UserRepository uRepo = new UserRepository();

        [Route("api/SignUp")]

        public IHttpActionResult Post([FromBody] User u)
        {
            uRepo.Insert(u);
            return Ok(u);
        }
    }
}
