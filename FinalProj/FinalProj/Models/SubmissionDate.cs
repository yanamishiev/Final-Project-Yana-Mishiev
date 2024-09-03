using System;
using System.Collections.Generic;

namespace FinalProj.Models;

public partial class SubmissionDate
{
    public int SubNum { get; set; }

    public string? SubmissionName { get; set; }

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public int? ProjNum { get; set; }

    public int? Id { get; set; }

    public virtual User? IdNavigation { get; set; }

    public virtual ProjectGroup? ProjNumNavigation { get; set; }
}
