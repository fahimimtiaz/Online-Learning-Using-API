using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using FinalProject.Repository;

namespace FinalProject.Attributes
{
    public class StudentAuthorizationAttribute : AuthorizationFilterAttribute
    {
        LoginRepository logrepo = new LoginRepository();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.Request.Headers.Authorization != null)
            {
                string encoded = actionContext.Request.Headers.Authorization.Parameter;
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
                string[] split = decoded.Split(new char[] { ':' });
                string UserName = split[0];
                string Password = split[1];
                string type = logrepo.checkUserType(UserName,Password);
                if (type == "Student" && logrepo.ValidateStudent(UserName, Password) != "invalid")
                {
                    string Name = logrepo.ValidateStudent(UserName, Password).ToString();
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Name), null);
                }
                else if (type == "Teacher" && logrepo.ValidateStudent(UserName, Password) != "invalid")
                {
                    string Name = logrepo.ValidateStudent(UserName, Password).ToString();
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Name), null);
                }
                else if (type == "Admin" && logrepo.ValidateStudent(UserName, Password) != "invalid")
                {
                    string Name = logrepo.ValidateStudent(UserName, Password).ToString();
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Name), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}