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
    public class LevelGroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public LevelGroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddLevelGroup")]
        public async Task<JsonResult> AddLevelGroup([FromBody] LevelGroup levelGroup)
        {
            try
            {
                _context.Add(levelGroup);
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