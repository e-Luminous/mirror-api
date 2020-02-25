using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mirror_api.Models;

namespace mirror_api.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public LevelController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("AddLevel")]
        public async Task<JsonResult> AddLevel([FromBody]Level level)
        {
            if (!ModelState.IsValid)
                return Json(new ApiMessage
                {
                    HasError = true,
                    Message = "InvalidModel"
                });
            _context.Add(level);

            try
            {
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
                    HasError = false,
                    Message = e.Message
                });
            }
        }
    }
}