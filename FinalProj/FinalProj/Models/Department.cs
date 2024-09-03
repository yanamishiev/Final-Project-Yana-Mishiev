using System;
using System.Collections.Generic;

namespace FinalProj.Models;

public partial class Department
{
    public int DepNum { get; set; }

    public string? NameDepartment { get; set; }

    public virtual ICollection<ProjectGroup> ProjectGroups { get; set; } = new List<ProjectGroup>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
