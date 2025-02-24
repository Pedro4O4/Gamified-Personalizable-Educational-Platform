using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Skill
{
    public int Sid { get; set; }

    public string Skill1 { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;

    public virtual ICollection<SkillProgression> SkillProgressions { get; set; } = new List<SkillProgression>();
}
