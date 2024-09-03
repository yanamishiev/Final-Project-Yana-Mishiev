using FinalProj.Models;

namespace WebApplication1.dto
{
    public class UserInProjectDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? NameProject { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
