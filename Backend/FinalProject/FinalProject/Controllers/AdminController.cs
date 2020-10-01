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
    public class AdminController : ApiController
    {
        OnlineStudentsRepository stdRepo = new OnlineStudentsRepository();


        [Route("api/Admins/Students")]

        //Get All Students Information
        public IHttpActionResult Get()
        {

            return Ok(stdRepo.GetAll());
        }

        //Get a Specific Student Information
        [Route("api/Admins/Students/{id}", Name = "GetStudentById")]
        public IHttpActionResult Get(int id)
        {
            OnlineStudent onlineStudent = stdRepo.GetById(id);


            if (onlineStudent == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(onlineStudent);
        }


        //Create A  New Student
        [Route("api/Admins/Students")]
        public IHttpActionResult Post(OnlineStudent onlineStudent)
        {
            stdRepo.Insert(onlineStudent);
            string url = Url.Link("GetStudentById", new { id = onlineStudent.StudentId });
            return Created(url, onlineStudent);
        }


        //Delete a Student
        [Route("api/Admins/Students/{id}")]
        public IHttpActionResult Delete(int id)
        {
            stdRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        //////////////////////// CRUD Operation for Teacher////////////////////////////////

        TeacherRepository techRepo = new TeacherRepository();

        [Route("api/Admins/Teachers")]

        //Get All Teachers Information
        public IHttpActionResult GetAllTeachers()
        {

            return Ok(techRepo.GetAll());
        }

        //Get a Specific Teacher Information
        [Route("api/Admins/Teachers/{id}", Name = "GetTeachersById")]
        public IHttpActionResult GetSpecificTeacher(int id)
        {
            Teacher tch = techRepo.GetById(id);


            if (tch == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(tch);
        }


        //Create A  New Teacher
        [Route("api/Admins/Teachers")]
        public IHttpActionResult Post(Teacher tch)
        {
            techRepo.Insert(tch);
            string url = Url.Link("GetTeachersById", new { id = tch.TeacherId });
            return Created(url, tch);
        }

        //Edit a Teacher Information
        [Route("api/Admins/Teachers/{id}")]
        public IHttpActionResult Put([FromBody] Teacher tch, [FromUri] int id)
        {
            tch.TeacherId = id;
            techRepo.Edit(tch);
            return Ok(tch);
        }

        //Delete a Teacher
        [Route("api/Admins/Teachers/{id}")]
        public IHttpActionResult DeleteTeacher(int id)
        {
            techRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        //////////////////////////////// CRUD Operation for Subject //////////////////////////////



        SubjectRepository subRepo = new SubjectRepository();

        //Get All Subjects 

        [Route("api/Admins/Subjects")]
        public IHttpActionResult GetSubjects()
        {

            return Ok(subRepo.GetAll());
        }


        //Get All Subjects of a Teacher 
        [Route("api/Admins/Teachers/{id}/Subjects/", Name = "GetSubjectsByTeacherId")]
        public IHttpActionResult GetSubjectsOfAteacher(int id)
        {

            return Ok(techRepo.GetSubjectByTeacher(id));
        }

        //Get a Specific Subject of a Teacher 
        [Route("api/Admins/Teachers/{tid}/Subjects/{sid}", Name = "GetASubjectsByTeacherId")]
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
        [Route("api/Admins/Teachers/{tid}/Subjects/")]
        public IHttpActionResult Post(Subject sub)
        {
            subRepo.Insert(sub);
            string url = Url.Link("GetASubjectByTeacherId", new { sid = sub.SubjectId, tid = sub.TeacherId });
            return Created(url, sub);
        }

        //Edit a Subject 
        [Route("api/Admins/Teachers/{tid}/Subjects/{sid}")]
        public IHttpActionResult Put([FromBody] Subject subject, int tid, int sid)
        {

            subject.SubjectId = sid;
            subRepo.Edit(subject);
            return Ok(subject);
        }

        //Delete A subject for a teacher 

        [Route("api/Admins/Teachers/{tid}/Subjects/{sid}")]
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


        /////////////////////////// CRUD Operation for Message ////////////////////////////////

        /*last MessageRepository msgRepo = new MessageRepository();

        //Get All Messages 

        [Route("api/Admins/Messages")]
        public IHttpActionResult GetMessages()
        {

            //return Ok(msgRepo.GetAll());
        }

        //Get All Messages of a Students 
        [Route("api/Admins/Students/{id}/Messages/", Name = "GetMessagesByStudentId")]
        public IHttpActionResult GetMessagesOfAstudent(int id)
        {

           // return Ok(stdRepo.GetMessageByStudent(id));
        }

        //Get a Specific Message of a Students 
        [Route("api/Admins/Students/{sid}/Messages/{mid}", Name = "GetAMessageByStudentId")]
        public IHttpActionResult GetAMessagesOfAstudent(int sid, int mid)
        {
            //List<Message> msgList = stdRepo.GetMessageByStudent(sid);

           // Message message = msgRepo.GetById(mid);
            bool check = false;
            foreach (var item in msgList)
            {
                if (item.MessageId == message.MessageId)
                    check = true;
            }

            if (message == null || check == false)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(message);
        }

        //Create a Message for a Student
        [Route("api/Admins/Students/{sid}/Messages/{mid}")]
        public IHttpActionResult Post(Message msg)
        {
            msgRepo.Insert(msg);
            string url = Url.Link("GetAMessageByStudentId", new { mid = msg.MessageId, sid = msg.StudentId });
            return Created(url, msg);
        }

        //Delete A Message for a Student 

        [Route("api/Admins/Students/{sid}/Messages/{mid}")]
        public IHttpActionResult DeleteAMessagesOfAstudent(int sid, int mid)
        {
            List<Message> msgList = stdRepo.GetMessageByStudent(sid);
            Message message = msgRepo.GetById(mid);
            bool check = false;
            foreach (var item in msgList)
            {
                if (item.MessageId == message.MessageId)
                    check = true;
            }

            if (check == false)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }

            msgRepo.Delete(mid);
            return StatusCode(HttpStatusCode.NoContent);
        }


        ////////////////////////// CRUD Operation for User //////////////////////////////////

        UserRepository userRepo = new UserRepository();

        [Route("api/Admins/Users")]
        public IHttpActionResult GetAllUser()
        {
            return Ok(userRepo.GetUser());
        }

        //Get a Specific User 
        [Route("api/Admins/Users/{id}", Name = "GetAUserByUserId")]
        public IHttpActionResult GetAUser(int id)
        {
            List<User> userList = userRepo.GetUser(id);

            User user = userRepo.GetById(id);
            bool check = false;
            foreach (var item in userList)
            {
                if (item.UserId == user.UserId)
                    check = true;
            }

            if (user == null || check == false)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(user);
        }*/
    }
}
