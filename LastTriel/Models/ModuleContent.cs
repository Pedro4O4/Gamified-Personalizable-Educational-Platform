using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class ModuleContent
{
    public int ModuleId { get; set; }

    public int Cid { get; set; }

    public string Content { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;
}
