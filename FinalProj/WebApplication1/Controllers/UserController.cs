using FinalProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        FprojectContext db = new FprojectContext();

        [HttpPost]
        [Route("SignUp")]

        public dynamic Sign(UserDto obj)
        {
            User user = new User();
            user.Id = obj.Id;
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Email = obj.Email;
            user.Passworde = obj.Passworde;
            user.ConfirmPassword = obj.ConfirmPassword;
            user.DepNum = obj.DepNum;
            user.ProjNum = obj.ProjNum;
            db.Users.Add(user);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, "done:)");

        }

        [HttpGet]
        [Route("getAllNames")]

        public dynamic GetNames()
        {
            try
            {
                var names = db.Users.Select(x => x.FirstName).ToList();
                return Ok(names);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving names: {ex.Message}");
            }
        }
    }
}
