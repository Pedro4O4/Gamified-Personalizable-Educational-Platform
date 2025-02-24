using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Ranking
{
    public int BoardId { get; set; }

    public int Sid { get; set; }

    public int Cid { get; set; }

    public int Rank { get; set; }

    public int TotalMarks { get; set; }

    public virtual LeaderBoard Board { get; set; } = null!;

    public virtual Course CidNavigation { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
