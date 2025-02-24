using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Admin
{
    public int Aid { get; set; }

    public virtual User AidNavigation { get; set; } = null!;
}
