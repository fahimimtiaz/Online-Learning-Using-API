using FinalProject.Attributes;
using FinalProject.Models;
using FinalProject.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class StudentController : ApiController
    {
        SubjectRepository subRepo = new SubjectRepository();
        CoursesOfStudentRepository cosRepo = new CoursesOfStudentRepository();
        RegistrationRepository regRepo = new RegistrationRepository();
        VideoRepository vidRepo = new VideoRepository();
        UserRepository uRepo = new UserRepository();
        OnlineStudentsRepository osRepo = new OnlineStudentsRepository();

      
        [Route("api/students/mycourses")]
        [StudentAuthorization]
        public IHttpActionResult Get(/*[FromUri] string name*/)
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;
            return Ok(cosRepo.GetCourseByStudent(Name));
        }

        [Route("api/students/enroll")]
        [StudentAuthorization]

        public IHttpActionResult PostEnroll([FromBody] CoursesOfStudent cos)
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;

            int subid=cos.CourseId;
            Subject ss = subRepo.GetSubDetaileById(subid);
            ss.StudentCount += 1;
            subRepo.Edit(ss);

            cos.TeacherId = ss.TeacherId;
            cosRepo.Insert(cos);

            Registration reg = new Registration();
            reg.SubjectId = cos.CourseId;
            reg.StudentName = Name;
            reg.Fee = ss.Price;
            regRepo.Insert(reg);

            return Ok(cos);
        }

        [Route("api/students/registration")]
        [StudentAuthorization]

        public IHttpActionResult GetRegistration()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;
             

            return Ok(regRepo.GetRegInfoByName(Name));
        }

        [Route("api/students/subjects/{id}/videos")]
        [StudentAuthorization]

        public IHttpActionResult GetVideo([FromUri] int id)
        {

            return Ok(vidRepo.GetVideoBySubject(id));
        }

        [Route("api/students/getUserInfo")]
        [StudentAuthorization]

        public IHttpActionResult GetUserInfo()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;
            return Ok(uRepo.getUserInfoByName(Name));
        }

        [Route("api/students/updateUserInfo")]
        [StudentAuthorization]

        public IHttpActionResult PutUserInfo([FromBody] User u)
        {
            uRepo.Edit(u);

           // string Name = Thread.CurrentPrincipal.Identity.Name;
            return Ok(u);
        }

        [Route("api/students/photoupload")]
       // [StudentAuthorization]
        public async Task<string> PostPhoto()
        {
           // string Nam = Thread.CurrentPrincipal.Identity.Name;

            //on = osRepo.getInfoByName(Nam);

            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/Uploaded/Videos2");


            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                string localFileName;
                string filePath;


                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;
                    //Remove Double quotes
                    name = name.Trim('"');

                    localFileName = file.LocalFileName;
                    filePath = Path.Combine(root, name);

                   

                   // on.ImageName = file.LocalFileName;
                   // on.ImagePath = Path.Combine(root, name);

                   // osRepo.Edit(on);

                    File.Move(localFileName, filePath);


                }

                //techRepo.Edit(teacher);

            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            return "Photo Uploaded";
        }
    }
}
