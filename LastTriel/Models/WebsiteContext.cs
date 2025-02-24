using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LastTriel.Models;

public partial class WebsiteContext : DbContext
{
    public WebsiteContext()
    {
    }

    public WebsiteContext(DbContextOptions<WebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acheivement> Acheivements { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Badge> Badges { get; set; }

    public virtual DbSet<CollaborativeQuest> CollaborativeQuests { get; set; }

    public virtual DbSet<ContentLibrary> ContentLibraries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<DisscussionForum> DisscussionForums { get; set; }

    public virtual DbSet<EmotionalFeedback> EmotionalFeedbacks { get; set; }

    public virtual DbSet<EmotionalFeedbackReview> EmotionalFeedbackReviews { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<HealthCondition> HealthConditions { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InteractionLog> InteractionLogs { get; set; }

    public virtual DbSet<LeaderBoard> LeaderBoards { get; set; }

    public virtual DbSet<Learner> Learners { get; set; }

    public virtual DbSet<LearnerMastery> LearnerMasteries { get; set; }

    public virtual DbSet<LearnersCollaboration> LearnersCollaborations { get; set; }

    public virtual DbSet<LearningActivity> LearningActivities { get; set; }

    public virtual DbSet<LearningGoal> LearningGoals { get; set; }

    public virtual DbSet<LearningPath> LearningPaths { get; set; }

    public virtual DbSet<LearningPathRule> LearningPathRules { get; set; }

    public virtual DbSet<LearningPreference> LearningPreferences { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<ModuleContent> ModuleContents { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PathReview> PathReviews { get; set; }

    public virtual DbSet<PersonalizationProfile> PersonalizationProfiles { get; set; }

    public virtual DbSet<PrerequisitesCourse> PrerequisitesCourses { get; set; }

    public virtual DbSet<Quest> Quests { get; set; }

    public virtual DbSet<QuestReward> QuestRewards { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    public virtual DbSet<RecivedNotification> RecivedNotifications { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillMasteryQuest> SkillMasteryQuests { get; set; }

    public virtual DbSet<SkillProgression> SkillProgressions { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }

    public virtual DbSet<SurveyResponse> SurveyResponses { get; set; }

    public virtual DbSet<TakenAssessment> TakenAssessments { get; set; }

    public virtual DbSet<TargetTrait> TargetTraits { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=website;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acheivement>(entity =>
        {
            entity.HasKey(e => e.AcheivementId).HasName("PK__acheivem__9DEBB02A984C52F5");

            entity.ToTable("acheivement");

            entity.HasIndex(e => e.Type, "ix_acheivement");

            entity.HasIndex(e => e.DateEarned, "ix_acheivement3");

            entity.HasIndex(e => e.Sid, "ix_acheivement4");

            entity.HasIndex(e => e.BadgeId, "ix_acheivement5");

            entity.Property(e => e.AcheivementId).HasColumnName("acheivement_id");
            entity.Property(e => e.BadgeId).HasColumnName("badge_id");
            entity.Property(e => e.DateEarned)
                .HasColumnType("datetime")
                .HasColumnName("date_earned");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("description");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("excellence")
                .HasColumnName("type");

            entity.HasOne(d => d.Badge).WithMany(p => p.Acheivements)
                .HasForeignKey(d => d.BadgeId)
                .HasConstraintName("FK__acheiveme__badge__42E1EEFE");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.Acheivements)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__acheivement__sid__41EDCAC5");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__admin__DE508E2EE4C06B3E");

            entity.ToTable("admin");

            entity.HasIndex(e => e.Aid, "ix_admin");

            entity.Property(e => e.Aid)
                .ValueGeneratedNever()
                .HasColumnName("aid");

            entity.HasOne(d => d.AidNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.Aid)
                .HasConstraintName("FK__admin__aid__3A81B327");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId).HasName("PK__assessme__00B98C26890D22C5");

            entity.ToTable("assessment");

            entity.HasIndex(e => e.AssessmentId, "ix_assessment");

            entity.HasIndex(e => e.Cid, "ix_assessment2");

            entity.HasIndex(e => e.ModuleId, "ix_assessment3");

            entity.HasIndex(e => new { e.ModuleId, e.Cid }, "ix_assessment4");

            entity.Property(e => e.AssessmentId)
                .ValueGeneratedNever()
                .HasColumnName("assessment_id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Criteria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("criteria");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("description");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.PassingMarks).HasColumnName("passing_marks");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.TotalMarks).HasColumnName("total_marks");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("quiz")
                .HasColumnName("type");
            entity.Property(e => e.Weightage).HasColumnName("weightage");

            entity.HasOne(d => d.Module).WithMany(p => p.Assessments)
                .HasForeignKey(d => new { d.ModuleId, d.Cid })
                .HasConstraintName("FK__assessment__66603565");
        });

        modelBuilder.Entity<Badge>(entity =>
        {
            entity.HasKey(e => e.BadgeId).HasName("PK__badge__E79896560478B32F");

            entity.ToTable("badge");

            entity.HasIndex(e => e.Criteria, "ix_badge");

            entity.HasIndex(e => e.Title, "ix_badge2");

            entity.HasIndex(e => e.Points, "ix_badge3");

            entity.Property(e => e.BadgeId)
                .ValueGeneratedNever()
                .HasColumnName("badge_id");
            entity.Property(e => e.Criteria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("criteria");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Points)
                .HasDefaultValueSql("('100')")
                .HasColumnName("points");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<CollaborativeQuest>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__collabor__9A0F00CD1C242819");

            entity.ToTable("collaborative_quest");

            entity.HasIndex(e => e.MaxParticipants, "ix_collaborative_quest");

            entity.Property(e => e.QuestId)
                .ValueGeneratedNever()
                .HasColumnName("quest_id");
            entity.Property(e => e.Deadline)
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            entity.Property(e => e.MaxParticipants)
                .HasDefaultValue(5)
                .HasColumnName("max_participants");

            entity.HasOne(d => d.Quest).WithOne(p => p.CollaborativeQuest)
                .HasForeignKey<CollaborativeQuest>(d => d.QuestId)
                .HasConstraintName("FK__collabora__quest__5224328E");
        });

        modelBuilder.Entity<ContentLibrary>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__content___655FE51083C305AC");

            entity.ToTable("content_library");

            entity.HasIndex(e => e.ContentId, "ix_content_library");

            entity.HasIndex(e => e.Title, "ix_content_library2");

            entity.HasIndex(e => e.ModuleId, "ix_content_library3");

            entity.HasIndex(e => e.Cid, "ix_content_library4");

            entity.Property(e => e.ContentId)
                .ValueGeneratedNever()
                .HasColumnName("content_id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.ContentUrl)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("content_url");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("description");
            entity.Property(e => e.Metadata)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("metadata");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("text")
                .HasColumnName("type");

            entity.HasOne(d => d.Module).WithMany(p => p.ContentLibraries)
                .HasForeignKey(d => new { d.ModuleId, d.Cid })
                .HasConstraintName("FK__content_library__619B8048");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__course__D837D05F10342244");

            entity.ToTable("course");

            entity.HasIndex(e => e.Cid, "ix_course");

            entity.HasIndex(e => e.Title, "ix_course2");

            entity.HasIndex(e => e.CreditPoints, "ix_course3");

            entity.Property(e => e.Cid)
                .ValueGeneratedNever()
                .HasColumnName("cid");
            entity.Property(e => e.CreditPoints).HasColumnName("credit_points");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("2")
                .HasColumnName("difficulty_level");
            entity.Property(e => e.LearningObjective)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("learning_objective");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<DisscussionForum>(entity =>
        {
            entity.HasKey(e => e.ForumId).HasName("PK__disscuss__69A2FA588BA93E53");

            entity.ToTable("disscussion_forum");

            entity.HasIndex(e => new { e.ModuleId, e.Cid }, "ix_disscussion_forum");

            entity.Property(e => e.ForumId).HasColumnName("forum_id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("description");
            entity.Property(e => e.LastActivity)
                .HasColumnType("datetime")
                .HasColumnName("last_activity");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Module).WithMany(p => p.DisscussionForums)
                .HasForeignKey(d => new { d.ModuleId, d.Cid })
                .HasConstraintName("FK__disscussion_foru__607251E5");
        });

        modelBuilder.Entity<EmotionalFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__emotiona__7A6B2B8CFA0425DA");

            entity.ToTable("emotional_feedback");

            entity.HasIndex(e => e.Sid, "ix_emotional_feedback");

            entity.HasIndex(e => e.EmotionalState, "ix_emotional_feedback2");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.EmotionalState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emotional_state");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");

            entity.HasOne(d => d.Activity).WithMany(p => p.EmotionalFeedbacks)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__emotional__activ__778AC167");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.EmotionalFeedbacks)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__emotional_f__sid__787EE5A0");
        });

        modelBuilder.Entity<EmotionalFeedbackReview>(entity =>
        {
            entity.HasKey(e => new { e.FeedbackId, e.InstructorId }).HasName("PK__emotiona__E075DEE229661EEC");

            entity.ToTable("emotional_feedback_review");

            entity.HasIndex(e => e.FeedbackId, "ix_emotional_feedback_review");

            entity.HasIndex(e => e.InstructorId, "ix_emotional_feedback_review2");

            entity.HasIndex(e => e.Feedback, "ix_emotional_feedback_review3");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.Feedback)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("feedback");

            entity.HasOne(d => d.FeedbackNavigation).WithMany(p => p.EmotionalFeedbackReviews)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("FK__emotional__feedb__0A9D95DB");

            entity.HasOne(d => d.Instructor).WithMany(p => p.EmotionalFeedbackReviews)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__emotional__instr__0B91BA14");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__enrollme__6D24AA7AED97A0E4");

            entity.ToTable("enrollment");

            entity.HasIndex(e => e.Sid, "ix_enrollment");

            entity.HasIndex(e => e.Cid, "ix_enrollment2");

            entity.HasIndex(e => e.Status, "ix_enrollment3");

            entity.HasIndex(e => e.EnrollmentDate, "ix_enrollment4");

            entity.Property(e => e.EnrollmentId).HasColumnName("enrollment_id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.CompletionDate)
                .HasColumnType("datetime")
                .HasColumnName("completion_date");
            entity.Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("enrolled")
                .HasColumnName("status");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__enrollment__cid__114A936A");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__enrollment__sid__10566F31");
        });

        modelBuilder.Entity<HealthCondition>(entity =>
        {
            entity.HasKey(e => new { e.Sid, e.OrderNumber, e.Condition }).HasName("PK__health_c__8CD72AB9538C316E");

            entity.ToTable("health_condition");

            entity.HasIndex(e => e.Sid, "ix_health_condition");

            entity.HasIndex(e => e.Condition, "ix_health_condition2");

            entity.HasIndex(e => e.OrderNumber, "ix_health_condition3");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("condition");

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.HealthConditions)
                .HasForeignKey(d => new { d.Sid, d.OrderNumber })
                .HasConstraintName("FK__health_condition__4AB81AF0");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__instruct__A1EF56E8AD285B1E");

            entity.ToTable("instructor");

            entity.HasIndex(e => e.InstructorId, "ix_instructor");

            entity.HasIndex(e => e.Name, "ix_instructor2");

            entity.HasIndex(e => e.ExpertiseArea, "ix_instructor3");

            entity.Property(e => e.InstructorId)
                .ValueGeneratedNever()
                .HasColumnName("instructor_id");
            entity.Property(e => e.ExpertiseArea)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("not-specified")
                .HasColumnName("expertise_area");
            entity.Property(e => e.LatestQualification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("not-specified")
                .HasColumnName("latest_qualification");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.InstructorNavigation).WithOne(p => p.Instructor)
                .HasForeignKey<Instructor>(d => d.InstructorId)
                .HasConstraintName("FK__instructo__instr__03F0984C");

            entity.HasMany(d => d.Cids).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "Teach",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("Cid")
                        .HasConstraintName("FK__teaches__cid__151B244E"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK__teaches__instruc__14270015"),
                    j =>
                    {
                        j.HasKey("InstructorId", "Cid").HasName("PK__teaches__4C6C2BED484FED59");
                        j.ToTable("teaches");
                        j.HasIndex(new[] { "InstructorId" }, "ix_teaches");
                        j.HasIndex(new[] { "Cid" }, "ix_teaches2");
                        j.IndexerProperty<int>("InstructorId").HasColumnName("instructor_id");
                        j.IndexerProperty<int>("Cid").HasColumnName("cid");
                    });
        });

        modelBuilder.Entity<InteractionLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__interact__9E2397E059649AFD");

            entity.ToTable("interaction_log");

            entity.HasIndex(e => e.ActionType, "ix_interaction_log2");

            entity.HasIndex(e => e.Sid, "ix_interaction_log5");

            entity.HasIndex(e => e.ActivityId, "ix_interaction_log6");

            entity.Property(e => e.LogId)
                .ValueGeneratedNever()
                .HasColumnName("log_id");
            entity.Property(e => e.ActionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("action_type");
            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.Duration).HasDefaultValue(60);
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");

            entity.HasOne(d => d.Activity).WithMany(p => p.InteractionLogs)
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK__interacti__activ__72C60C4A");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.InteractionLogs)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__interaction__sid__73BA3083");
        });

        modelBuilder.Entity<LeaderBoard>(entity =>
        {
            entity.HasKey(e => e.BoardId).HasName("PK__leader_b__FB1C96E9B3BCCEAD");

            entity.ToTable("leader_board");

            entity.HasIndex(e => e.Season, "ix_leader_board");

            entity.Property(e => e.BoardId)
                .ValueGeneratedNever()
                .HasColumnName("board_id");
            entity.Property(e => e.Season)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("winter")
                .HasColumnName("season");
        });

        modelBuilder.Entity<Learner>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__learner__DDDFDD36C26EDE55");

            entity.ToTable("learner");

            entity.HasIndex(e => e.Country, "ix_learner");

            entity.HasIndex(e => new { e.Fname, e.Lname }, "ix_learner2");

            entity.HasIndex(e => e.BirthDate, "ix_learner3");

            entity.HasIndex(e => e.Sid, "ix_learner4");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.BirthDate)
                .HasDefaultValue(new DateOnly(1900, 1, 1))
                .HasColumnName("birth_date");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Culture)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("culture");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lname");

            entity.HasMany(d => d.PrerequisitesCourses).WithMany(p => p.Sids)
                .UsingEntity<Dictionary<string, object>>(
                    "CompletedPrerequisite",
                    r => r.HasOne<PrerequisitesCourse>().WithMany()
                        .HasForeignKey("Cid", "Prerequisite")
                        .HasConstraintName("FK__completed_prereq__6DCC4D03"),
                    l => l.HasOne<Learner>().WithMany()
                        .HasForeignKey("Sid")
                        .HasConstraintName("FK__completed_p__sid__6CD828CA"),
                    j =>
                    {
                        j.HasKey("Sid", "Cid", "Prerequisite").HasName("PK__complete__991104816F5B228A");
                        j.ToTable("completed_prerequisites");
                        j.HasIndex(new[] { "Prerequisite" }, "ix_completed_prerequisites");
                        j.HasIndex(new[] { "Sid" }, "ix_completed_prerequisites2");
                        j.HasIndex(new[] { "Cid" }, "ix_completed_prerequisites3");
                        j.IndexerProperty<int>("Sid").HasColumnName("sid");
                        j.IndexerProperty<int>("Cid").HasColumnName("cid");
                        j.IndexerProperty<string>("Prerequisite")
                            .HasMaxLength(100)
                            .IsUnicode(false)
                            .HasColumnName("prerequisite");
                    });
        });

        modelBuilder.Entity<LearnerMastery>(entity =>
        {
            entity.HasKey(e => new { e.Sid, e.QuestId }).HasName("PK__learner___147F2D3A58C15892");

            entity.ToTable("learner_mastery");

            entity.HasIndex(e => e.CompletionStatus, "ix_learner_mastery");

            entity.HasIndex(e => e.Sid, "ix_learner_mastery2");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("incomplete")
                .HasColumnName("completion_status");

            entity.HasOne(d => d.Quest).WithMany(p => p.LearnerMasteries)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK__learner_m__quest__5BAD9CC8");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.LearnerMasteries)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__learner_mas__sid__5AB9788F");
        });

        modelBuilder.Entity<LearnersCollaboration>(entity =>
        {
            entity.HasKey(e => new { e.QuestId, e.Sid }).HasName("PK__learners__E7D2FD1ED5ACDED5");

            entity.ToTable("learners_collaboration");

            entity.HasIndex(e => e.CompletetionStatus, "ix_learners_collaboration");

            entity.HasIndex(e => e.Sid, "ix_learners_collaboration2");

            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.CompletetionStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("incomplete")
                .HasColumnName("completetion_status");

            entity.HasOne(d => d.Quest).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK__learners___quest__55F4C372");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.LearnersCollaborations)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__learners_co__sid__56E8E7AB");
        });

        modelBuilder.Entity<LearningActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__learning__482FBD63B8AA5D54");

            entity.ToTable("learning_activity");

            entity.HasIndex(e => e.ActivityId, "ix_learning_activity");

            entity.HasIndex(e => e.ModuleId, "ix_learning_activity2");

            entity.HasIndex(e => e.Cid, "ix_learning_activity3");

            entity.HasIndex(e => new { e.ModuleId, e.Cid }, "ix_learning_activity4");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("activity_type");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Instruction)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("instruction");
            entity.Property(e => e.MaxPoints).HasColumnName("max_points");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");

            entity.HasOne(d => d.Module).WithMany(p => p.LearningActivities)
                .HasForeignKey(d => new { d.ModuleId, d.Cid })
                .HasConstraintName("FK__learning_activit__6E01572D");
        });

        modelBuilder.Entity<LearningGoal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__learning__76679A2437B53D21");

            entity.ToTable("learning_goal");

            entity.Property(e => e.GoalId)
                .ValueGeneratedNever()
                .HasColumnName("goal_id");
            entity.Property(e => e.Deadline)
                .HasDefaultValueSql("(datepart(year,getdate())+datepart(year,(1)))")
                .HasColumnType("datetime")
                .HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("yet to be determined")
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("incomplete")
                .HasColumnName("status");

            entity.HasMany(d => d.Sids).WithMany(p => p.Goals)
                .UsingEntity<Dictionary<string, object>>(
                    "LearningGoal1",
                    r => r.HasOne<Learner>().WithMany()
                        .HasForeignKey("Sid")
                        .HasConstraintName("FK__learning_go__sid__25518C17"),
                    l => l.HasOne<LearningGoal>().WithMany()
                        .HasForeignKey("GoalId")
                        .HasConstraintName("FK__learning___goal___245D67DE"),
                    j =>
                    {
                        j.HasKey("GoalId", "Sid").HasName("PK__learning__0BBA67F7D3BCD61B");
                        j.ToTable("learning_goals");
                        j.HasIndex(new[] { "GoalId" }, "ix_learning_goals");
                        j.HasIndex(new[] { "Sid" }, "ix_learning_goals2");
                        j.IndexerProperty<int>("GoalId").HasColumnName("goal_id");
                        j.IndexerProperty<int>("Sid").HasColumnName("sid");
                    });
        });

        modelBuilder.Entity<LearningPath>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__learning__464F800D773572C6");

            entity.ToTable("learning_path");

            entity.HasIndex(e => e.Sid, "ix_learning_path");

            entity.HasIndex(e => e.OrderNumber, "ix_learning_path2");

            entity.HasIndex(e => e.CompletionStatus, "ix_learning_path3");

            entity.HasIndex(e => new { e.Sid, e.OrderNumber }, "ix_learning_path4");

            entity.Property(e => e.PathId).HasColumnName("path_id");
            entity.Property(e => e.CompletionStatus)
                .HasDefaultValue(0f)
                .HasColumnName("completion_status");
            entity.Property(e => e.CustomContent)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("custom_content");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.Sid).HasColumnName("sid");

            entity.HasOne(d => d.PersonalizationProfile).WithMany(p => p.LearningPaths)
                .HasForeignKey(d => new { d.Sid, d.OrderNumber })
                .HasConstraintName("FK__learning_path__7C4F7684");
        });

        modelBuilder.Entity<LearningPathRule>(entity =>
        {
            entity.HasKey(e => new { e.ApadtiveRule, e.PathId }).HasName("PK__learning__DF14AC0D2FEF8AEB");

            entity.ToTable("learning_path_rules");

            entity.HasIndex(e => e.ApadtiveRule, "ix_learning_path_rules");

            entity.HasIndex(e => e.PathId, "ix_learning_path_rules2");

            entity.Property(e => e.ApadtiveRule)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apadtive_rule");
            entity.Property(e => e.PathId).HasColumnName("path_id");

            entity.HasOne(d => d.Path).WithMany(p => p.LearningPathRules)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__learning___path___7F2BE32F");
        });

        modelBuilder.Entity<LearningPreference>(entity =>
        {
            entity.HasKey(e => new { e.Sid, e.Preference }).HasName("PK__learning__DA46C09467372B3D");

            entity.ToTable("learning_preferences");

            entity.HasIndex(e => e.Sid, "ix_learning_preferences");

            entity.HasIndex(e => e.Preference, "ix_learning_preferences2");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Preference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("preference");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.LearningPreferences)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__learning_pr__sid__4316F928");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.Cid }).HasName("PK__modules__F7AE7B5613E014DD");

            entity.ToTable("modules");

            entity.HasIndex(e => e.ModuleId, "ix_modules");

            entity.HasIndex(e => e.Title, "ix_modules2");

            entity.HasIndex(e => e.DifficultyLevel, "ix_modules3");

            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.DifficultyLevel)
                .HasDefaultValue(2)
                .HasColumnName("difficulty_level");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("url");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Modules)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__modules__cid__5535A963");
        });

        modelBuilder.Entity<ModuleContent>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.Cid, e.Content }).HasName("PK__module_c__4A34238F264CC1A1");

            entity.ToTable("module_content");

            entity.HasIndex(e => e.ModuleId, "ix_module_content");

            entity.HasIndex(e => e.Content, "ix_module_content2");

            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Content)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("content");

            entity.HasOne(d => d.Module).WithMany(p => p.ModuleContents)
                .HasForeignKey(d => new { d.ModuleId, d.Cid })
                .HasConstraintName("FK__module_content__5812160E");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842F439319EB");

            entity.ToTable("notification");

            entity.HasIndex(e => e.Urgency, "ix_notification");

            entity.HasIndex(e => e.TimeStamp, "ix_notification2");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.Message)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Urgency)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("low")
                .HasColumnName("urgency");
        });

        modelBuilder.Entity<PathReview>(entity =>
        {
            entity.HasKey(e => new { e.InstructorId, e.PathId }).HasName("PK__path_rev__658BAEE831E17C59");

            entity.ToTable("path_review");

            entity.HasIndex(e => e.InstructorId, "ix_path_review");

            entity.HasIndex(e => e.PathId, "ix_path_review2");

            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.PathId).HasColumnName("path_id");
            entity.Property(e => e.Feedback)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("feedback");

            entity.HasOne(d => d.Instructor).WithMany(p => p.PathReviews)
                .HasForeignKey(d => d.InstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__path_revi__instr__06CD04F7");

            entity.HasOne(d => d.Path).WithMany(p => p.PathReviews)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__path_revi__path___07C12930");
        });

        modelBuilder.Entity<PersonalizationProfile>(entity =>
        {
            entity.HasKey(e => new { e.Sid, e.OrderNumber }).HasName("PK__personal__2AEF3E7B3E15E689");

            entity.ToTable("personalization_profile");

            entity.HasIndex(e => e.Sid, "ix_personalization_profile");

            entity.HasIndex(e => e.OrderNumber, "ix_personalization_profile2");

            entity.HasIndex(e => e.PreferedContentType, "ix_personalization_profile3");

            entity.HasIndex(e => e.PersonalityType, "ix_personalization_profile4");

            entity.HasIndex(e => e.EmotionalState, "ix_personalization_profile5");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.EmotionalState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("sad")
                .HasColumnName("emotional_state");
            entity.Property(e => e.PersonalityType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("curious")
                .HasColumnName("personality_type");
            entity.Property(e => e.PreferedContentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prefered_content_type");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.PersonalizationProfiles)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__personaliza__sid__47DBAE45");
        });

        modelBuilder.Entity<PrerequisitesCourse>(entity =>
        {
            entity.HasKey(e => new { e.Cid, e.Prerequisite }).HasName("PK__prerequi__4CED9B75577EC7A1");

            entity.ToTable("prerequisites_course");

            entity.HasIndex(e => e.Cid, "ix_prerequisites_course");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Prerequisite)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("prerequisite");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.PrerequisitesCourses)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__prerequisit__cid__5070F446");
        });

        modelBuilder.Entity<Quest>(entity =>
        {
            entity.HasKey(e => e.QuestId).HasName("PK__quest__9A0F00CD0027A278");

            entity.ToTable("quest");

            entity.HasIndex(e => e.DifficultyLevel, "ix_quest");

            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.Criteria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("pass the basics")
                .HasColumnName("criteria");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("2")
                .HasColumnName("difficulty_level");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<QuestReward>(entity =>
        {
            entity.HasKey(e => new { e.RewardId, e.QuestId, e.Sid }).HasName("PK__quest_re__C3A8B66D4FF0BA47");

            entity.ToTable("quest_reward");

            entity.HasIndex(e => e.RewardId, "ix_quest_reward2");

            entity.HasIndex(e => e.QuestId, "ix_quest_reward3");

            entity.HasIndex(e => e.Sid, "ix_quest_reward4");

            entity.Property(e => e.RewardId).HasColumnName("reward_id");
            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.TimeEarned)
                .HasColumnType("datetime")
                .HasColumnName("time_earned");

            entity.HasOne(d => d.Quest).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK__quest_rew__quest__690797E6");

            entity.HasOne(d => d.Reward).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.RewardId)
                .HasConstraintName("FK__quest_rew__rewar__681373AD");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.QuestRewards)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__quest_rewar__sid__69FBBC1F");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => new { e.BoardId, e.Sid }).HasName("PK__ranking__86C16B3AA0771718");

            entity.ToTable("ranking");

            entity.HasIndex(e => e.BoardId, "ix_ranking");

            entity.HasIndex(e => e.Sid, "ix_ranking2");

            entity.HasIndex(e => e.Cid, "ix_ranking3");

            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Rank).HasColumnName("rank");
            entity.Property(e => e.TotalMarks).HasColumnName("total_marks");

            entity.HasOne(d => d.Board).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.BoardId)
                .HasConstraintName("FK__ranking__board_i__1AD3FDA4");

            entity.HasOne(d => d.CidNavigation).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.Cid)
                .HasConstraintName("FK__ranking__cid__1CBC4616");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__ranking__sid__1BC821DD");
        });

        modelBuilder.Entity<RecivedNotification>(entity =>
        {
            entity.HasKey(e => new { e.NotificationId, e.Sid }).HasName("PK__recived___9D8479FC2818BDD2");

            entity.ToTable("recived_notification");

            entity.HasIndex(e => e.NotificationId, "ix_recived_notification");

            entity.HasIndex(e => e.Sid, "ix_recived_notification2");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");

            entity.HasOne(d => d.Notification).WithMany(p => p.RecivedNotifications)
                .HasForeignKey(d => d.NotificationId)
                .HasConstraintName("FK__recived_n__notif__3493CFA7");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.RecivedNotifications)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__recived_not__sid__3587F3E0");
        });

        modelBuilder.Entity<Reward>(entity =>
        {
            entity.HasKey(e => e.RewardId).HasName("PK__reward__3DD599BC8AC5F033");

            entity.ToTable("reward");

            entity.HasIndex(e => e.Type, "ix_reward");

            entity.Property(e => e.RewardId)
                .ValueGeneratedNever()
                .HasColumnName("reward_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("none")
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("cash")
                .HasColumnName("type");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => new { e.Sid, e.Skill1 }).HasName("PK__skills__7E2FFF69F47B8E26");

            entity.ToTable("skills");

            entity.HasIndex(e => e.Sid, "idx_skills");

            entity.HasIndex(e => e.Skill1, "idx_skills2");

            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Skill1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skill");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.Skills)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__skills__sid__403A8C7D");
        });

        modelBuilder.Entity<SkillMasteryQuest>(entity =>
        {
            entity.HasKey(e => new { e.QuestId, e.Skill }).HasName("PK__skill_ma__39FF2292AFBBFFFD");

            entity.ToTable("skill_mastery_quest");

            entity.HasIndex(e => e.QuestId, "ix_skill_mastery_quest");

            entity.Property(e => e.QuestId).HasColumnName("quest_id");
            entity.Property(e => e.Skill)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("skill");

            entity.HasOne(d => d.Quest).WithMany(p => p.SkillMasteryQuests)
                .HasForeignKey(d => d.QuestId)
                .HasConstraintName("FK__skill_mas__quest__4E53A1AA");
        });

        modelBuilder.Entity<SkillProgression>(entity =>
        {
            entity.HasKey(e => e.ProgressionId).HasName("PK__skill_pr__F405992229A8B1FB");

            entity.ToTable("skill_progression");

            entity.HasIndex(e => e.ProficiencyLevel, "ix_skill_progression");

            entity.HasIndex(e => e.SkillName, "ix_skill_progression2");

            entity.HasIndex(e => e.TimeStamp, "ix_skill_progression3");

            entity.HasIndex(e => e.Sid, "ix_skill_progression4");

            entity.HasIndex(e => new { e.SkillName, e.Sid }, "ix_skill_progression6");

            entity.Property(e => e.ProgressionId)
                .ValueGeneratedNever()
                .HasColumnName("progression_id");
            entity.Property(e => e.ProficiencyLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("newbie")
                .HasColumnName("proficiency_level");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skill_name");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");

            entity.HasOne(d => d.Skill).WithMany(p => p.SkillProgressions)
                .HasForeignKey(d => new { d.Sid, d.SkillName })
                .HasConstraintName("FK__skill_progressio__3D2915A8");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.SurveyId).HasName("PK__survey__9DC31A07878909AF");

            entity.ToTable("survey");

            entity.HasIndex(e => e.Title, "ix_survey");

            entity.Property(e => e.SurveyId)
                .ValueGeneratedNever()
                .HasColumnName("survey_id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<SurveyQuestion>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.Question }).HasName("PK__survey_q__7469363CA382D1CD");

            entity.ToTable("survey_questions");

            entity.HasIndex(e => e.SurveyId, "ix_survey_questions");

            entity.HasIndex(e => e.Question, "ix_survey_questions2");

            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.Question)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("question");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestions)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("FK__survey_qu__surve__2A164134");
        });

        modelBuilder.Entity<SurveyResponse>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.Sid, e.Question, e.Response }).HasName("PK__survey_r__81E1CE1A9D97613B");

            entity.ToTable("survey_responses");

            entity.HasIndex(e => e.Response, "ix_survey_responses");

            entity.HasIndex(e => e.SurveyId, "ix_survey_responses2");

            entity.HasIndex(e => e.Sid, "ix_survey_responses3");

            entity.HasIndex(e => e.Question, "ix_survey_responses4");

            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.Question)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("question");
            entity.Property(e => e.Response)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("response");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.SurveyResponses)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__survey_resp__sid__2DE6D218");

            entity.HasOne(d => d.SurveyQuestion).WithMany(p => p.SurveyResponses)
                .HasForeignKey(d => new { d.SurveyId, d.Question })
                .HasConstraintName("FK__survey_responses__2CF2ADDF");
        });

        modelBuilder.Entity<TakenAssessment>(entity =>
        {
            entity.HasKey(e => new { e.AssessmentId, e.Sid }).HasName("PK__taken_as__7D6471F5C2F52CDC");

            entity.ToTable("taken_assessment");

            entity.HasIndex(e => e.AssessmentId, "ix_taken_assessment");

            entity.HasIndex(e => e.Sid, "ix_taken_assessment2");

            entity.HasIndex(e => e.ScoredPoints, "ix_taken_assessment3");

            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.Sid).HasColumnName("sid");
            entity.Property(e => e.ScoredPoints).HasColumnName("scored_points");

            entity.HasOne(d => d.Assessment).WithMany(p => p.TakenAssessments)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("FK__taken_ass__asses__693CA210");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.TakenAssessments)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__taken_asses__sid__6A30C649");
        });

        modelBuilder.Entity<TargetTrait>(entity =>
        {
            entity.HasKey(e => new { e.ModuleId, e.Cid, e.Trait }).HasName("PK__target_t__CE042C4E123EC1C1");

            entity.ToTable("target_traits");

            entity.HasIndex(e => e.ModuleId, "ix_target_traits");

            entity.HasIndex(e => e.Trait, "ix_target_traits2");

            entity.HasIndex(e => e.Cid, "ix_target_traits3");

            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Trait)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("trait");

            entity.HasOne(d => d.Module).WithMany(p => p.TargetTraits)
                .HasForeignKey(d => new { d.ModuleId, d.Cid })
                .HasConstraintName("FK__target_traits__5AEE82B9");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FBA303B97");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164EA6536AD").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__users__F3DBC572845FCE35").IsUnique();

            entity.HasIndex(e => e.Username, "ix_users");

            entity.HasIndex(e => e.Email, "ix_users2");

            entity.HasIndex(e => e.Role, "ix_users3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
