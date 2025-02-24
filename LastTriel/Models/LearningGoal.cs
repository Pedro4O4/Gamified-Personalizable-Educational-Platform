using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class LearningGoal
{
    public int GoalId { get; set; }

    public string? Status { get; set; }

    public DateTime? Deadline { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Learner> Sids { get; set; } = new List<Learner>();
}
