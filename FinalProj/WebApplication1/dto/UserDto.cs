using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FinalProj.Models;

namespace WebApplication1.dto
{
    public class UserDto
    {

        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Passworde { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int? ProjNum { get; set; }

        public int? DepNum { get; set; }


    }
}