using FinalProj.Models;

namespace WebApplication1.dto
{
    public class DepartmentDTO
    {
        public int DepNum { get; set; }

        public string NameDepartment { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
