using FinalProj.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectGroupController : Controller
    {
        FprojectContext db = new FprojectContext();
        [HttpGet]
        [Route("ProjectGroup")]
        public IActionResult GetGroupProject()
        {
            var projGroup = db.ProjectGroups
                                 .Select(pg => new { pg.ProjNum, pg.NameProject })
                                 .ToList();

            return Ok(projGroup);
        }

    }
}
