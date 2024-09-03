using FinalProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        FprojectContext db = new FprojectContext();

        [HttpGet]
        [Route("Departments")]
        public IActionResult GetDepartments()
        {
            var departments = db.Departments
                                 .Select(d => new { d.DepNum, d.NameDepartment })
                                 .ToList();

            return Ok(departments);
        }

    }
}
