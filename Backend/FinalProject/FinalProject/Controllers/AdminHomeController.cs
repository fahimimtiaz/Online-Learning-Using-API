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
    public class AdminHomeController : ApiController
    {
        RegistrationRepository regRepo = new RegistrationRepository();
        TeacherFinancialRepository teaFinRepo = new TeacherFinancialRepository();
        MessageRepository msgRepo = new MessageRepository();
        UserRepository uRepo = new UserRepository();
        TeacherRepository tRepo = new TeacherRepository();
        OnlineStudentsRepository osRepo = new OnlineStudentsRepository();

        [Route("api/AdminHome/StdFinancials")]
        [StudentAuthorization]

        public IHttpActionResult GetStdFin()
        {
            return Ok(regRepo.GetAllRegInfo());
        }

        [Route("api/AdminHome/TeaFinancials")]
        [StudentAuthorization]

        public IHttpActionResult GetTeaFin()
        {
            return Ok(teaFinRepo.getTeacherFinancials());
        }

        [Route("api/AdminHome/GetMyMsgs")]
        [StudentAuthorization]

        public IHttpActionResult GetMyMsg()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;
            return Ok(msgRepo.GetMessagesByName(Name));
        }

        [Route("api/AdminHome/sendMsgs")]
        [StudentAuthorization]

        public IHttpActionResult PostMsg([FromBody] Message msg)
        {
            string N = Thread.CurrentPrincipal.Identity.Name;
            string SseType = msgRepo.getSenderTypeByName(N);
            msg.SenderName = N;
            msg.SenderType = SseType;
            msgRepo.Insert(msg);

            return Ok(msg);
        }
        [Route("api/AdminHome/allusers")]
        [StudentAuthorization]
        public IHttpActionResult GetAllUser()
        {
            return Ok(uRepo.GetAll());
        }
        [Route("api/AdminHome/allteachers")]
        [StudentAuthorization]
        public IHttpActionResult GetAllTeacher()
        {
            return Ok(tRepo.GetAll());
        }
        [Route("api/AdminHome/allStudents")]
        [StudentAuthorization]
        public IHttpActionResult GetAllStudets()
        {
            return Ok(osRepo.GetAll());
        }
    }
}
