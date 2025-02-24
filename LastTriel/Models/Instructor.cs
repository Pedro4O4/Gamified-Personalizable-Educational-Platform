using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string Name { get; set; } = null!;

    public string LatestQualification { get; set; } = null!;

    public string ExpertiseArea { get; set; } = null!;

    public virtual ICollection<EmotionalFeedbackReview> EmotionalFeedbackReviews { get; set; } = new List<EmotionalFeedbackReview>();

    public virtual User InstructorNavigation { get; set; } = null!;

    public virtual ICollection<PathReview> PathReviews { get; set; } = new List<PathReview>();

    public virtual ICollection<Course> Cids { get; set; } = new List<Course>();
}
