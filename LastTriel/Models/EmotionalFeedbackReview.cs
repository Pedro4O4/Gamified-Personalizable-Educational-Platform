using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class EmotionalFeedbackReview
{
    public int FeedbackId { get; set; }

    public int InstructorId { get; set; }

    public string Feedback { get; set; } = null!;

    public virtual EmotionalFeedback FeedbackNavigation { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;
}
