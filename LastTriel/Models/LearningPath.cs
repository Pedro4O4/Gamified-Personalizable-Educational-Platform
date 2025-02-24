using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class LearningPath
{
    public int PathId { get; set; }

    public int Sid { get; set; }

    public int OrderNumber { get; set; }

    public float? CompletionStatus { get; set; }

    public string? CustomContent { get; set; }

    public virtual ICollection<LearningPathRule> LearningPathRules { get; set; } = new List<LearningPathRule>();

    public virtual ICollection<PathReview> PathReviews { get; set; } = new List<PathReview>();

    public virtual PersonalizationProfile PersonalizationProfile { get; set; } = null!;
}
