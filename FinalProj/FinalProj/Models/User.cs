using System;
using System.Collections.Generic;

namespace FinalProj.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Passworde { get; set; }

    public string? ConfirmPassword { get; set; }

    public string? Email { get; set; }

    public int? DepNum { get; set; }

    public int? ProjNum { get; set; }

    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    public virtual Department? DepNumNavigation { get; set; }

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ProjectGroup? ProjNumNavigation { get; set; }

    public virtual ICollection<SubmissionDate> SubmissionDates { get; set; } = new List<SubmissionDate>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public virtual ICollection<CalendarEvent> EventNums { get; set; } = new List<CalendarEvent>();

    public virtual ICollection<File> FileNums { get; set; } = new List<File>();

    public virtual ICollection<Task> TaskNums { get; set; } = new List<Task>();
}
