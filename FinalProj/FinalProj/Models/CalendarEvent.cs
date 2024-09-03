using System;
using System.Collections.Generic;

namespace FinalProj.Models;

public partial class CalendarEvent
{
    public int EventNum { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? EventType { get; set; }

    public TimeSpan? StartHour { get; set; }

    public TimeSpan? EndHour { get; set; }

    public int? ProjNum { get; set; }

    public int? Id { get; set; }

    public virtual User? IdNavigation { get; set; }

    public virtual ProjectGroup? ProjNumNavigation { get; set; }

    public virtual ICollection<User> Ids { get; set; } = new List<User>();

    public virtual ICollection<Task> TaskNums { get; set; } = new List<Task>();
}
