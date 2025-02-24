using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class HealthCondition
{
    public int Sid { get; set; }

    public string Condition { get; set; } = null!;

    public int OrderNumber { get; set; }

    public virtual PersonalizationProfile PersonalizationProfile { get; set; } = null!;
}
