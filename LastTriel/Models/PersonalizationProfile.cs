using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class PersonalizationProfile
{
    public int Sid { get; set; }

    public int OrderNumber { get; set; }

    public string PreferedContentType { get; set; } = null!;

    public string? EmotionalState { get; set; }

    public string? PersonalityType { get; set; }

    public virtual ICollection<HealthCondition> HealthConditions { get; set; } = new List<HealthCondition>();

    public virtual ICollection<LearningPath> LearningPaths { get; set; } = new List<LearningPath>();

    public virtual Learner SidNavigation { get; set; } = null!;
}
