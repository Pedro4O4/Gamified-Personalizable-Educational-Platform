using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class LearningActivity
{
    public int ActivityId { get; set; }

    public int ModuleId { get; set; }

    public int Cid { get; set; }

    public string ActivityType { get; set; } = null!;

    public string? Instruction { get; set; }

    public int MaxPoints { get; set; }

    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual ICollection<InteractionLog> InteractionLogs { get; set; } = new List<InteractionLog>();

    public virtual Module Module { get; set; } = null!;
}
