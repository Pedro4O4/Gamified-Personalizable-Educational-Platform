using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class SurveyResponse
{
    public string Response { get; set; } = null!;

    public int SurveyId { get; set; }

    public int Sid { get; set; }

    public string Question { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;

    public virtual SurveyQuestion SurveyQuestion { get; set; } = null!;
}
