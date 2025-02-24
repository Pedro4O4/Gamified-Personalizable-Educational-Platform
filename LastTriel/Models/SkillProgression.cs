using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class SkillProgression
{
    public int ProgressionId { get; set; }

    public string ProficiencyLevel { get; set; } = null!;

    public int Sid { get; set; }

    public string SkillName { get; set; } = null!;

    public DateTime? TimeStamp { get; set; }

    public virtual Skill Skill { get; set; } = null!;
}
