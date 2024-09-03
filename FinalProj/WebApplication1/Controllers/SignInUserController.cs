using FinalProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInUserController : ControllerBase
    {
        FprojectContext db = new FprojectContext();
        [HttpPost]
        [Route("SignIn")]

        public void SignIn (SignInUserDTO obj)
        {
            User? user = db.Users.Where(u => u.Id == obj.Id).FirstOrDefault();
            user.Id = obj.Id;
            user.Passworde = obj.Passworde;
            db.Users.Add(user);
            db.SaveChanges();

        }

        [HttpPost]
        [Route("SignInSucsseful")]
        public IActionResult SignInUs([FromBody] SignInUserDTO user)
        {
            //כאן אני בודקת שאכן הכל תקין גם עם הסיסמא וגם עם השם
            var systemUser = db.Users.FirstOrDefault(x => x.Id == user.Id);

            if (systemUser == null)
            {
                return NotFound("User not found.");
            }

            if (systemUser.Passworde != user.Passworde)
            {
                return Unauthorized("Invalid credentials.");
            }
            var userInfo = new
            {
                systemUser.Id,
                systemUser.FirstName,
                systemUser.LastName,
                systemUser.ProjNum,
                systemUser.DepNum,
                systemUser.Email
        };



            return Ok(userInfo);
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {

            return Ok(new { message = "Logged out successfully" });
        }

    }
}
