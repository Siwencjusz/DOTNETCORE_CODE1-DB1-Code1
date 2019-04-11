using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly BloggingContext _context;

        public ApiController(BloggingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(OkResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync();
            var comment = await _context.Comments.FirstOrDefaultAsync();
            var blogComment = await _context.BlogCommentsView.FirstOrDefaultAsync();
            return Ok();
        }
    }
}