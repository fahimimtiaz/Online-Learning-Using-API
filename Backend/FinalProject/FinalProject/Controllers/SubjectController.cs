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
    public class SubjectController : ApiController
    {
        TeacherRepository techRepo = new TeacherRepository();
        SubjectRepository subRepo = new SubjectRepository();

        //Get All Subjects 

        [Route("api/Subjects")]
        public IHttpActionResult Get()
        {

            return Ok(subRepo.GetAll());
        }


        //Get All Subjects of a Teacher 
        [Route("api/Teachers/{id}/Subjects/", Name = "GetSubjectByTeacherId")]
        public IHttpActionResult Get(int id)
        {

            return Ok(techRepo.GetSubjectByTeacher(id));
        }

        //Get a Specific Subject of a Teacher 
        [Route("api/Teachers/{tid}/Subjects/{sid}", Name = "GetASubjectByTeacherId")]
        public IHttpActionResult Get(int tid, int sid)
        {
            List<Subject> subList = techRepo.GetSubjectByTeacher(tid);

            Subject subject = subRepo.GetById(sid);
            bool check = false;
            foreach (var item in subList)
            {
                if (item.SubjectId == subject.SubjectId)
                    check = true;
            }

            if (subject == null || check == false)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(subject);
        }

        //Create a Subject for a Teacher
        [Route("api/Teachers/{tid}/Subjects/")]
        public IHttpActionResult Post(Subject sub)
        {
            subRepo.Insert(sub);
            string url = Url.Link("GetASubjectByTeacherId", new { sid = sub.SubjectId, tid = sub.TeacherId });
            return Created(url, sub);
        }

        //Edit a Subject 
        [Route("api/Teachers/{tid}/Subjects/{sid}")]
        public IHttpActionResult Put([FromBody] Subject subject, int tid, int sid)
        {

            subject.SubjectId = sid;
            subRepo.Edit(subject);
            return Ok(subject);
        }

        //Delete A subject for a teacher 

        [Route("api/Teachers/{tid}/Subjects/{sid}")]
        public IHttpActionResult Delete(int tid, int sid)
        {
            List<Subject> subList = techRepo.GetSubjectByTeacher(tid);
            Subject subject = subRepo.GetById(sid);
            bool check = false;
            foreach (var item in subList)
            {
                if (item.SubjectId == subject.SubjectId)
                    check = true;
            }

            if (check == false)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }

            subRepo.Delete(sid);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
