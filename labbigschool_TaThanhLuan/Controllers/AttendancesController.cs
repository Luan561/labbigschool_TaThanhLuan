using labbigschool_TaThanhLuan.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace labbigschool_TaThanhLuan.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbConText;
         public AttendancesController()
        {
            _dbConText = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var userId = User.Identity.GetUserId();
            if (_dbConText.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == courseId))
                return BadRequest("The Attendance already existsl");
            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendeeId = userId
            };

            _dbConText.Attendances.Add(attendance);
            _dbConText.SaveChanges();

            return Ok();
        }
    }
}
