using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class ContentLibrary
{
    public int ContentId { get; set; }

    public int ModuleId { get; set; }

    public int Cid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Metadata { get; set; }

    public string? Type { get; set; }

    public string? ContentUrl { get; set; }

    public virtual Module Module { get; set; } = null!;
}
