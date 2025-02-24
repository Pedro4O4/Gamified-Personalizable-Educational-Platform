using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class QuestReward
{
    public int RewardId { get; set; }

    public int QuestId { get; set; }

    public int Sid { get; set; }

    public DateTime? TimeEarned { get; set; }

    public virtual Quest Quest { get; set; } = null!;

    public virtual Reward Reward { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
