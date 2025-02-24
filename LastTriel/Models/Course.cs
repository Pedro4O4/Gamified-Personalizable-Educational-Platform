using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Course
{
    public int Cid { get; set; }

    public string Title { get; set; } = null!;

    public string LearningObjective { get; set; } = null!;

    public int CreditPoints { get; set; }

    public string? DifficultyLevel { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual ICollection<PrerequisitesCourse> PrerequisitesCourses { get; set; } = new List<PrerequisitesCourse>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
