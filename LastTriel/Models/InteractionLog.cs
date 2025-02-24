using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class InteractionLog
{
    public int LogId { get; set; }

    public int ActivityId { get; set; }

    public int Sid { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string ActionType { get; set; } = null!;

    public int? Duration { get; set; }

    public virtual LearningActivity Activity { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
