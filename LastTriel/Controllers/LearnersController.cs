using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LastTriel.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace LastTriel.Controllers
{
    public class LearnersController : Controller
    {
        private readonly WebsiteContext _context;
        private readonly string _connectionString;

        public LearnersController(WebsiteContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection"); // Initialize the connection string
        }

        // GET: Learners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Learners.ToListAsync());
        }

        // GET: Learners/GetLearnerCourses/5
        public async Task<IActionResult> GetLearnerCourses(int learnerId)
        {
            var courses = new List<Course>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GetLearnerCourses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@learnerId", learnerId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var course = new Course
                            {
                                Cid = reader.GetInt32(reader.GetOrdinal("cid")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                LearningObjective = reader.GetString(reader.GetOrdinal("learning_objective")),
                                CreditPoints = reader.GetInt32(reader.GetOrdinal("credit_points")),
                                DifficultyLevel = reader.GetString(reader.GetOrdinal("difficulty_level")),
                                Description = reader.GetString(reader.GetOrdinal("description"))
                            };
                            courses.Add(course);
                        }
                    }
                }
            }

            return View(courses);
        }
        public async Task<IActionResult> GetHighestScoredAssessment()
        {
            var highestScoredAssessments = new List<Assessment>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("Highestgrade", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var assessment = new Assessment
                            {
                                AssessmentId = reader.GetInt32(reader.GetOrdinal("assessment_id")),
                                Cid = reader.GetInt32(reader.GetOrdinal("cid")),
                                Criteria = reader.GetString(reader.GetOrdinal("criteria")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                ModuleId = reader.GetInt32(reader.GetOrdinal("module_id")),
                                PassingMarks = reader.GetInt32(reader.GetOrdinal("passing_marks")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                TotalMarks = reader.GetInt32(reader.GetOrdinal("total_marks")),
                                Type = reader.GetString(reader.GetOrdinal("type")),
                                Weightage = reader.GetInt32(reader.GetOrdinal("weightage"))
                            };
                            highestScoredAssessments.Add(assessment);
                        }
                    }
                }
            }

            return View(highestScoredAssessments);
        }



        public async Task<IActionResult> GetCourseAssessments(int cid, int learnerId)
        {
            var assessments = new List<Assessment>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("GetCourseAssessments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@cid", cid);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var assessment = new Assessment
                            {
                                AssessmentId = reader.GetInt32(reader.GetOrdinal("assessment_id")),
                                ModuleId = reader.GetInt32(reader.GetOrdinal("module_id")),
                                Cid = reader.GetInt32(reader.GetOrdinal("cid")),
                                Type = reader.GetString(reader.GetOrdinal("type")),
                                TotalMarks = reader.GetInt32(reader.GetOrdinal("total_marks")),
                                PassingMarks = reader.GetInt32(reader.GetOrdinal("passing_marks")),
                                Weightage = reader.GetInt32(reader.GetOrdinal("weightage")),
                                Criteria = reader.GetString(reader.GetOrdinal("criteria")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                Title = reader.GetString(reader.GetOrdinal("title"))
                            };
                            assessments.Add(assessment);
                        }
                    }
                }
            }

            ViewBag.LearnerId = learnerId;
            return View(assessments);
        }

        public async Task<IActionResult> GetModules(int id)
        {
            var modules = new List<Module>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetModulesByCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CourseID", id));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var module = new Module
                            {
                                ModuleId = reader.GetInt32(0),
                                Cid = reader.GetInt32(1),
                                Title = reader.GetString(2),
                                DifficultyLevel = reader.GetInt32(3),
                                Url = reader.GetString(4),
                            };
                            modules.Add(module);
                        }
                    }
                }
            }

            return View(modules);
        }
        public async Task<IActionResult> GetLearningActivity(int cid, int moduleId)
        {
            var learningActivities = new List<LearningActivity>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetLearningActivity", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@cid", cid));
                    command.Parameters.Add(new SqlParameter("@module_id", moduleId));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var activity = new LearningActivity
                            {
                                ActivityId = reader.GetInt32(reader.GetOrdinal("activity_id")),
                                ModuleId = reader.GetInt32(reader.GetOrdinal("module_id")),
                                Cid = reader.GetInt32(reader.GetOrdinal("cid")),
                                ActivityType = reader.GetString(reader.GetOrdinal("activity_type")),
                                Instruction = reader.GetString(reader.GetOrdinal("instruction")),
                                MaxPoints = reader.GetInt32(reader.GetOrdinal("max_points"))
                            };
                            learningActivities.Add(activity);
                        }
                    }
                }
            }

            return View(learningActivities);
        }


        public async Task<IActionResult> GetTakenAssessment(int? learnerId)
        {
            if (learnerId == null)
            {
                return NotFound();
            }

            var takenAssessments = await _context.TakenAssessments
                .FromSqlRaw("EXEC GetLearnerAssessments @p0", learnerId)
                .AsNoTracking()
                .ToListAsync();

            // Perform the Include operation on the client side
            var assessmentsWithDetails = takenAssessments
                .Select(t => new TakenAssessment
                {
                    Sid = t.Sid,
                    AssessmentId = t.AssessmentId,
                    ScoredPoints = t.ScoredPoints,
                    Assessment = _context.Assessments.FirstOrDefault(a => a.AssessmentId == t.AssessmentId)
                })
                .ToList();

            if (!assessmentsWithDetails.Any())
            {
                return NotFound();
            }

            return View(assessmentsWithDetails);
        }
        public async Task<IActionResult> GetAssessmentBreakdown(int learnerId, int assessmentId)
        {
            var breakdownData = new List<dynamic>();

            var takenAssessment = await _context.TakenAssessments
                .FirstOrDefaultAsync(t => t.Sid == learnerId && t.AssessmentId == assessmentId);

            if (takenAssessment == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .FirstOrDefaultAsync(a => a.AssessmentId == assessmentId);

            if (assessment == null)
            {
                return NotFound();
            }

            var totalMarks = assessment.TotalMarks;
            var scoredPoints = takenAssessment.ScoredPoints;

            // Calculate Percentage
            var percentage = CalculatePercentage(scoredPoints, totalMarks);
            var performance = DeterminePerformance(percentage);

            var breakdown = new
            {
                TotalMarks = totalMarks,
                ScoredPoints = scoredPoints,
                Percentage = percentage,
                Performance = performance
            };
            breakdownData.Add(breakdown);

            return View(breakdownData);
        }

        private double CalculatePercentage(int scoredPoints, int totalMarks)
        {
            return (scoredPoints * 100.0) / totalMarks;
        }

        private string DeterminePerformance(double percentage)
        {
            if (percentage >= 90)
                return "Excellent";
            else if (percentage >= 75)
                return "VeryGood";
            else if(percentage >= 65)
                return "Good";
            else if (percentage >= 50)
                return "Average";
            else
                return "Fail";
        }


        // GET: Learners/Courseregister
        public IActionResult Courseregister(int learnerId)
        {
            ViewBag.LearnerId = learnerId;
            return View();
        }

        // POST: Learners/Courseregister
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Courseregister(int learnerId, int courseId)
        {
            string message;
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("Courseregister", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@LearnerID", learnerId));
                    command.Parameters.Add(new SqlParameter("@CourseID", courseId));

                    var result = new SqlParameter("@Result", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(result);

                    await command.ExecuteNonQueryAsync();

                    message = result.Value.ToString();
                }
            }

            ViewBag.Message = message;
            ViewBag.LearnerId = learnerId;
            return View();
        }
        public async Task<IActionResult> ViewingMessages(int learnerId)
        {
            var notifications = new List<Notification>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ViewNot", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@learnerID", learnerId));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var notification = new Notification
                            {
                                NotificationId = reader.GetInt32(reader.GetOrdinal("notification_id")),
                                Urgency = reader.GetString(reader.GetOrdinal("Urgency"))
                            };
                            notifications.Add(notification);
                        }
                    }
                }
            }

            ViewBag.LearnerId = learnerId;
            return View(notifications);
        }
        public async Task<IActionResult> ViewingTextOfMessages(int learnerId, string urgency, int notificationId)
        {
            var notifications = new List<Notification>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("ViewMsg", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@learnerID", learnerId));
                    command.Parameters.Add(new SqlParameter("@urgency", urgency));
                    command.Parameters.Add(new SqlParameter("@notfication_id", notificationId));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var notification = new Notification
                            {
                                NotificationId = reader.GetInt32(reader.GetOrdinal("notification_id")),
                                Message = reader.GetString(reader.GetOrdinal("message")),
                                TimeStamp = reader.IsDBNull(reader.GetOrdinal("time_stamp"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime(reader.GetOrdinal("time_stamp")),
                            };
                            notifications.Add(notification);
                        }
                    }
                }
            }

            return View(notifications);
        }





        public async Task<IActionResult> UpdateMessageStatus(int learnerId, int notificationId, bool readStatus)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("NotificationUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@LearnerID", learnerId));
                    command.Parameters.Add(new SqlParameter("@notificationID", notificationId));
                    command.Parameters.Add(new SqlParameter("@ReadStatus", readStatus));

                    await command.ExecuteNonQueryAsync();
                }
            }

            if (readStatus)
            {
                TempData["Message"] = "Read successfully";
            }
            else
            {
                TempData["Message"] = "Unread successfully";
            }

            return RedirectToAction("ViewingMessages", new { learnerId = learnerId });
        }
        public async Task<IActionResult> IsMessageRead(int sid, int notificationId)
        {
            bool isRead = false;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("viewTheRead", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@sid", sid));
                    command.Parameters.Add(new SqlParameter("@notification_id", notificationId));

                    var result = await command.ExecuteScalarAsync();
                    if (result != null)
                    {
                        isRead = (bool)result;
                    }
                }
            }

            ViewBag.IsRead = isRead;
            return View();
        }



        // GET: Learners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // GET: Learners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Learners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sid,Fname,Lname,Gender,Country,Culture,BirthDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(learner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(learner);
        }

        // GET: Learners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners.FindAsync(id);
            if (learner == null)
            {
                return NotFound();
            }
            return View(learner);
        }

        // POST: Learners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sid,Fname,Lname,Gender,Country,Culture,BirthDate")] Learner learner)
        {
            if (id != learner.Sid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(learner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.Sid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(learner);
        }

        // GET: Learners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = await _context.Learners
                .FirstOrDefaultAsync(m => m.Sid == id);
            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // POST: Learners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learner = await _context.Learners.FindAsync(id);
            if (learner != null)
            {
                _context.Learners.Remove(learner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnerExists(int id)
        {
            return _context.Learners.Any(e => e.Sid == id);
        }
    }


}

