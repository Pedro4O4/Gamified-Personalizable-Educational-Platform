using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int Sid { get; set; }

    public int Cid { get; set; }

    public DateTime? CompletionDate { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public string? Status { get; set; }

    public virtual Course CidNavigation { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
