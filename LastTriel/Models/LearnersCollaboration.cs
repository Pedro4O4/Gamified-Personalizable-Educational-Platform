using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class LearnersCollaboration
{
    public int QuestId { get; set; }

    public int Sid { get; set; }

    public string? CompletetionStatus { get; set; }

    public virtual Quest Quest { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
