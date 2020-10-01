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
    [RoutePrefix("api/Teachers")]
    public class TeacherController : ApiController
    {
        TeacherRepository techRepo = new TeacherRepository();

        
        SubjectRepository subRepo = new SubjectRepository();
        MyMaterialRepository matRepo = new MyMaterialRepository();
        VideoRepository vidRepo = new VideoRepository();


        [Route("")]

        //Get All Teachers Information
        public IHttpActionResult Get()
        {

            return Ok(techRepo.GetAll());
        }

        //Get a Specific Teacher Information
        [Route("OwnProfile", Name = "GetTeacherById")]
        [StudentAuthorization]
        public IHttpActionResult GetProfile()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;

            int id = techRepo.GetTeacherId(Name);

            List<Teacher> teacher = techRepo.GetTeacherById(id);

            //return Ok(techRepo.GetTeacherByThread(Name));
            return Ok(teacher);
        }



        //Create A  New Teacher
        [Route("")]
        
        public IHttpActionResult Post(Teacher tch)
        {
            techRepo.Insert(tch);
            string url = Url.Link("GetPostById", new { id = tch.TeacherId });
            return Created(url, tch);

        }

        //Upload a Photo

        [Route("PhotoUpload")]
        [HttpPost]
        public async Task<IHttpActionResult> PostPhoto()
        {

            string Name = Thread.CurrentPrincipal.Identity.Name;

            int id = techRepo.GetTeacherId("testT");

            Teacher teacher = techRepo.GetById(id);


            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/Uploaded/ProImage/");


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



                    teacher.ImageName = file.LocalFileName;
                    teacher.ImagePath = Path.Combine(root, name);

                    techRepo.Edit(teacher);

                    File.Move(localFileName, filePath);


                }

                //techRepo.Edit(teacher);

            }
            catch (Exception e)
            {
                //return $"Error: {e.Message}";
                return StatusCode(HttpStatusCode.ExpectationFailed);
            }

            return Ok();
        }



        //Edit a Teacher Information
        [Route("UpdateProfile")]
        public IHttpActionResult PutTeacher([FromBody] Teacher tch)
        {
            //string Name = Thread.CurrentPrincipal.Identity.Name;

            int id = techRepo.GetTeacherId("testT");

            tch.TeacherId = id;
            techRepo.Edit(tch);
            return Ok(tch);
        }

        //Delete a Teacher
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            techRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Get All Subjects of a Teacher 
        [Route("Subjects")]
        [StudentAuthorization]
        public IHttpActionResult GetSubject()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;

            int id = techRepo.GetTeacherId(Name);

            List<Subject> subjects = techRepo.GetSubjectByTeacher(id);

            return Ok(subjects);
        }

        //////////////////////////////////////////////////////////////////////////

        //Create a New Material
        /*[Route("Subjects/MaterialUpload/{id}")]

        [HttpPost]
        public async Task<IHttpActionResult> PostMaterial(int id)
        {

            //subRepo.Insert(sub);
            //string url = Url.Link("GetASubjectByTeacherId", new { sid = sub.SubjectId, tid = sub.TeacherId });
            //return Created(url, sub);

            MyMaterial myMaterial = new MyMaterial();
            myMaterial.SubjectId = id;



            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/Uploaded/Materials/");



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



                    myMaterial.MaterialName = file.LocalFileName;
                    myMaterial.MaterialLink = Path.Combine(root, name);

                    matRepo.Insert(myMaterial);

                    File.Move(localFileName, filePath);


                }
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.ExpectationFailed);
            }

            return Ok(myMaterial);
        }*/






        [Route("Subjects/VideoUpload")]

        [HttpPost]
        public async Task<string> PostVideos()
        {

            Video video = new Video();
            video.SubjectId = 1;

            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/Uploaded/Videos/");



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



                    video.VideoName = file.LocalFileName;
                    video.VideoPath = Path.Combine(root, name);

                    vidRepo.Insert(video);

                    File.Move(localFileName, filePath);


                }
            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }


            return "Video Uploaded";
        }

    }
}
