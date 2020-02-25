using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mirror_api.Models;

namespace mirror_api.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddGroup")]
        public async Task<JsonResult> AddGroup([FromBody] Group group)
        {
            if (!ModelState.IsValid)
                return Json(new ApiMessage
                {
                    HasError = true,
                    Message = "InvalidModel"
                });
            _context.Add(group);

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
                    HasError = true,
                    Message = e.Message
                });
            }
        }
    }
}