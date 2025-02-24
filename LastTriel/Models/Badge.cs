using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Badge
{
    public int BadgeId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Criteria { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int Points { get; set; }

    public virtual ICollection<Acheivement> Acheivements { get; set; } = new List<Acheivement>();
}
