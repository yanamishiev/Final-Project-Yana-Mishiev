using System;
using System.Collections.Generic;

namespace FinalProj.Models;

public partial class Task
{
    public int TaskNum { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsCompleted { get; set; }

    public DateTime? DueDate { get; set; }

    public int? ProjNum { get; set; }

    public int? Id { get; set; }

    public virtual User? IdNavigation { get; set; }

    public virtual ProjectGroup? ProjNumNavigation { get; set; }

    public virtual ICollection<CalendarEvent> EventNums { get; set; } = new List<CalendarEvent>();

    public virtual ICollection<User> Ids { get; set; } = new List<User>();
}
