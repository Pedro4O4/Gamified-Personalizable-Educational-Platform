using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class EmotionalFeedback
{
    public int FeedbackId { get; set; }

    public int Sid { get; set; }

    public DateTime? TimeStamp { get; set; }

    public int ActivityId { get; set; }

    public string EmotionalState { get; set; } = null!;

    public virtual LearningActivity Activity { get; set; } = null!;

    public virtual ICollection<EmotionalFeedbackReview> EmotionalFeedbackReviews { get; set; } = new List<EmotionalFeedbackReview>();

    public virtual Learner SidNavigation { get; set; } = null!;
}
