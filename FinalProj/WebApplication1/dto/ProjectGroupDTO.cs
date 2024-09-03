using FinalProj.Models;

namespace WebApplication1.dto
{
    public class ProjectGroupDTO
    {
        public int ProjNum { get; set; }

        public string? NameProject { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
