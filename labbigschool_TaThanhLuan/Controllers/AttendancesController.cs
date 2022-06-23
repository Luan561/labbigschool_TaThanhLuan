using labbigschool_TaThanhLuan.DTOs;
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
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbConText.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already existsl");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            }; 

            _dbConText.Attendances.Add(attendance);
            _dbConText.SaveChanges();

            return Ok();
        }
    }
}
