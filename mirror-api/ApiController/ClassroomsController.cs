using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mirror_api.Models;

namespace mirror_api.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassroomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddClassroom")]
        public async Task<IActionResult> AddClassroom([FromBody] Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiMessage
                {
                    HasError = true,
                    Message = "InvalidModel",
                });
            }

            try
            {
                _context.Add(classroom);
                _context.Entry(classroom.LevelGroup).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return Json(new ApiMessage
                {
                    HasError = false,
                    Message = "Success"
                });
            }
            catch (Exception e)
            {
                return Json(new ApiMessage
                {
                    HasError = true,
                    Message = e.Message
                });
            }
        }

        [HttpGet("GetClassrooms")]
        public async Task<IActionResult> GetClassrooms()
        {
            var classrooms = await _context.Classrooms
                .Select(lg => new Classroom
                {
                    ClassroomId = lg.ClassroomId,
                    AccessCode = lg.AccessCode,
                    ClassroomTitle = lg.ClassroomTitle,
                    ColorPicker = lg.ColorPicker,
                    LevelGroup = new LevelGroup
                    {
                        MGroupId = lg.LevelGroup.MGroupId,
                        MLevelId = lg.LevelGroup.MLevelId,
                        Level = new Level
                        {
                            LevelId = lg.LevelGroup.Level.LevelId,
                            LevelName = lg.LevelGroup.Level.LevelName,
                        },
                        Group = new Group
                        {
                            GroupId = lg.LevelGroup.Level.LevelId,
                            GroupName = lg.LevelGroup.Group.GroupName
                        }
                    }
                })
                .ToListAsync();
            return Json(classrooms);
        }

        [HttpPost("UpgradeClassroom")]
        public async Task<IActionResult> UpgradeClassroom([FromBody] Classroom classroom)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ApiMessage
                {
                    HasError = true,
                    Message = "InvalidModel",
                });
            }

            try
            {
                _context.Update(classroom);
                _context.Entry(classroom.LevelGroup).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return Json(new ApiMessage
                {
                    HasError = false,
                    Message = "Success"
                });
            }
            catch (Exception e)
            {
                return Json(new ApiMessage
                {
                    HasError = true,
                    Message = e.Message
                });
            }
        }
    }
}
