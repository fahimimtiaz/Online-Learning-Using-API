using FinalProject.Attributes;
using FinalProject.Models;
using FinalProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace FinalProject.Controllers
{
    //[RoutePrefix("api/OnlineStudents")]
    public class OnlineStudentController : ApiController
    {
        OnlineStudentsRepository stdRepo = new OnlineStudentsRepository();


     /*   [Route("")]

        //Get All Students Information
        public IHttpActionResult Get()
        {

            return Ok(stdRepo.GetAll());
        }*/

        //Get a Specific Student Information

        [Route("api/OnlineStudents/getinfo")]
        [StudentAuthorization]
        public IHttpActionResult Get()
        {
            string Na = Thread.CurrentPrincipal.Identity.Name;
          

            return Ok(stdRepo.GetOnlineStudentsHey(Na));
        }


        //Create A  New Student
        /*   [Route("")]
           public IHttpActionResult Post(OnlineStudent onlineStudent)
           {
               stdRepo.Insert(onlineStudent);
               string url = Url.Link("GetPostById", new { id = onlineStudent.StudentId });
               return Created(url, onlineStudent);
           }*/


        //Edit a Student Information
        [Route("api/OnlineStudents/putinfo")]
        [StudentAuthorization]
        public IHttpActionResult Put([FromBody] OnlineStudent onli)
        {

            stdRepo.Edit(onli) ;
            return Ok(onli);
        }

      /*  //Delete a Student
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            stdRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }*/
    }
}
