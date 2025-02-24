using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class PrerequisitesCourse
{
    public int Cid { get; set; }

    public string Prerequisite { get; set; } = null!;

    public virtual Course CidNavigation { get; set; } = null!;

    public virtual ICollection<Learner> Sids { get; set; } = new List<Learner>();
}
