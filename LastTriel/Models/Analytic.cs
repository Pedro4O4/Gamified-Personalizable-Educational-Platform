using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Analytic
{
    public int AssessmentId { get; set; }

    public int Sid { get; set; }

    public int ScoredPoints { get; set; }

    public double? AverageScore { get; set; }

    public string? Performance { get; set; }

    public virtual Assessment Assessment { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
