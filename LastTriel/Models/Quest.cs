using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Quest
{
    public int QuestId { get; set; }

    public string? DifficultyLevel { get; set; }

    public string Criteria { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual CollaborativeQuest? CollaborativeQuest { get; set; }

    public virtual ICollection<LearnerMastery> LearnerMasteries { get; set; } = new List<LearnerMastery>();

    public virtual ICollection<LearnersCollaboration> LearnersCollaborations { get; set; } = new List<LearnersCollaboration>();

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();

    public virtual ICollection<SkillMasteryQuest> SkillMasteryQuests { get; set; } = new List<SkillMasteryQuest>();
}
