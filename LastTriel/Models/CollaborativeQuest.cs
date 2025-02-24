using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class CollaborativeQuest
{
    public int QuestId { get; set; }

    public DateTime? Deadline { get; set; }

    public int? MaxParticipants { get; set; }

    public virtual Quest Quest { get; set; } = null!;
}
