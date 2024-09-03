using System;
using System.Collections.Generic;

namespace FinalProj.Models;

public partial class File
{
    public int FileNum { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public int? ProjNum { get; set; }

    public int? Id { get; set; }

    public virtual User? IdNavigation { get; set; }

    public virtual ProjectGroup? ProjNumNavigation { get; set; }

    public virtual ICollection<User> Ids { get; set; } = new List<User>();
}
