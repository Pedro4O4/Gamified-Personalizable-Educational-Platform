using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Acheivement
{
    public int AcheivementId { get; set; }

    public int Sid { get; set; }

    public int BadgeId { get; set; }

    public string? Description { get; set; }

    public DateTime DateEarned { get; set; }

    public string? Type { get; set; }

    public virtual Badge Badge { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
