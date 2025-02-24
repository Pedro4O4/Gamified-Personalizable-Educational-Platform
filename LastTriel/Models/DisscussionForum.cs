using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class DisscussionForum
{
    public int ForumId { get; set; }

    public int ModuleId { get; set; }

    public int Cid { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? LastActivity { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? Description { get; set; }

    public virtual Module Module { get; set; } = null!;
}
