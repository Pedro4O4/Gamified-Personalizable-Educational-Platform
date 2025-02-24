using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public int Cid { get; set; }

    public string Title { get; set; } = null!;

    public int? DifficultyLevel { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual Course CidNavigation { get; set; } = null!;

    public virtual ICollection<ContentLibrary> ContentLibraries { get; set; } = new List<ContentLibrary>();

    public virtual ICollection<DisscussionForum> DisscussionForums { get; set; } = new List<DisscussionForum>();

    public virtual ICollection<LearningActivity> LearningActivities { get; set; } = new List<LearningActivity>();

    public virtual ICollection<ModuleContent> ModuleContents { get; set; } = new List<ModuleContent>();

    public virtual ICollection<TargetTrait> TargetTraits { get; set; } = new List<TargetTrait>();
}
