using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class TakenAssessment
{
    public int AssessmentId { get; set; }

    public int Sid { get; set; }

    public int ScoredPoints { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
