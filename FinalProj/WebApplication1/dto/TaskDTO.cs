using FinalProj.Models;

namespace WebApplication1.dto
{
    public class TaskDTO
    {
        public int TaskNum { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime? DueDate { get; set; }

        public int? ProjNum { get; set; }

        public virtual ProjectGroup? ProjNumNavigation { get; set; }

        public virtual ICollection<CalendarEvent> EventNums { get; set; } = new List<CalendarEvent>();

    }
}
