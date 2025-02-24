using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class LeaderBoard
{
    public int BoardId { get; set; }

    public string? Season { get; set; }

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();
}
