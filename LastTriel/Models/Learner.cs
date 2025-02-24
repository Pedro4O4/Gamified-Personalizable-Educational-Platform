using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Learner
{
    public int Sid { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public bool? Gender { get; set; }

    public string? Country { get; set; }

    public string? Culture { get; set; }

    public DateOnly BirthDate { get; set; }

    public virtual ICollection<Acheivement> Acheivements { get; set; } = new List<Acheivement>();

    public virtual ICollection<EmotionalFeedback> EmotionalFeedbacks { get; set; } = new List<EmotionalFeedback>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<InteractionLog> InteractionLogs { get; set; } = new List<InteractionLog>();

    public virtual ICollection<LearnerMastery> LearnerMasteries { get; set; } = new List<LearnerMastery>();

    public virtual ICollection<LearnersCollaboration> LearnersCollaborations { get; set; } = new List<LearnersCollaboration>();

    public virtual ICollection<LearningPreference> LearningPreferences { get; set; } = new List<LearningPreference>();

    public virtual ICollection<PersonalizationProfile> PersonalizationProfiles { get; set; } = new List<PersonalizationProfile>();

    public virtual ICollection<QuestReward> QuestRewards { get; set; } = new List<QuestReward>();

    public virtual ICollection<Ranking> Rankings { get; set; } = new List<Ranking>();

    public virtual ICollection<RecivedNotification> RecivedNotifications { get; set; } = new List<RecivedNotification>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();

    public virtual ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();

    public virtual ICollection<TakenAssessment> TakenAssessments { get; set; } = new List<TakenAssessment>();

    public virtual ICollection<LearningGoal> Goals { get; set; } = new List<LearningGoal>();

    public virtual ICollection<PrerequisitesCourse> PrerequisitesCourses { get; set; } = new List<PrerequisitesCourse>();
}
