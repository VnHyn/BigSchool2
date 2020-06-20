using Microsoft.AspNet.Identity;
using System.Web.Http;
using static BigSchool3.Migrations.BigSchool3.Models;
using BigSchool3.DTOs;
using System.Data.Entity;
using System.Web.Configuration;
using BigSchool3.Models;
using ApplicationDbContext = BigSchool3.Migrations.BigSchool3.Models.ApplicationDbContext;

namespace BigSchool3.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            DbContext = new ApplicationDbContext();
        }

        internal Migrations.BigSchool3.Models.ApplicationDbContext DbContext { get => _dbContext; set => _dbContext = value; }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a = a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists");
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
