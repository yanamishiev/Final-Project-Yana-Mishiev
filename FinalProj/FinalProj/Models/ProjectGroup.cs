using System;
using System.Collections.Generic;

namespace FinalProj.Models;

public partial class ProjectGroup
{
    public int ProjNum { get; set; }

    public string? NameProject { get; set; }

    public int? DepNum { get; set; }

    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    public virtual Department? DepNumNavigation { get; set; }

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ICollection<SubmissionDate> SubmissionDates { get; set; } = new List<SubmissionDate>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
