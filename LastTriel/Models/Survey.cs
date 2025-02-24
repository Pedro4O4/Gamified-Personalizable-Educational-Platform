using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Survey
{
    public int SurveyId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();
}
