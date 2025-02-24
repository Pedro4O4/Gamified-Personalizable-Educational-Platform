using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class SurveyQuestion
{
    public int SurveyId { get; set; }

    public string Question { get; set; } = null!;

    public virtual Survey Survey { get; set; } = null!;

    public virtual ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
}
