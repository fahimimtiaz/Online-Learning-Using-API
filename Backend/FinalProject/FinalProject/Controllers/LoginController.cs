using FinalProject.Models;
using FinalProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace FinalProject.Controllers
{
    [RoutePrefix("api/logins")]
    public class LoginController : ApiController
    {
        LoginRepository logrepo = new LoginRepository();

      
        [Route("validate")]
        public IHttpActionResult PostLogin([FromBody] User u)
        {
            string UserName = u.UserName;
            string Password = u.Password;
            string type = logrepo.checkUserType(UserName, Password);

            if (type == "Student" && logrepo.ValidateStudent(UserName, Password) != "invalid")
            {
                string Name = logrepo.ValidateStudent(UserName, Password).ToString();
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Name), null);

                return Ok(type);

            }
            else if (type == "Teacher" && logrepo.ValidateStudent(UserName, Password) != "invalid")
            {
                string Name = logrepo.ValidateStudent(UserName, Password).ToString();
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Name), null);

                return Ok(type);

            }
            else if (type == "Admin" && logrepo.ValidateStudent(UserName, Password) != "invalid")
            {
                string Name = logrepo.ValidateStudent(UserName, Password).ToString();
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Name), null);

                return Ok(type);

            }
            else
            {
                
                return Unauthorized();
            }
        }
    }
}
