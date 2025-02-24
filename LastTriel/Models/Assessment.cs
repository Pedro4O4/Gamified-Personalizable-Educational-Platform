using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Assessment
{
    public int AssessmentId { get; set; }

    public int ModuleId { get; set; }

    public int Cid { get; set; }

    public string? Type { get; set; }

    public int TotalMarks { get; set; }

    public int PassingMarks { get; set; }

    public int Weightage { get; set; }

    public string Criteria { get; set; } = null!;

    public string? Description { get; set; }

    public string Title { get; set; } = null!;

    public virtual Module Module { get; set; } = null!;

    public virtual ICollection<TakenAssessment> TakenAssessments { get; set; } = new List<TakenAssessment>();
}
