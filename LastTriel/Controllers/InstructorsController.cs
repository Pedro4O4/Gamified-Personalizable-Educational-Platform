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
    public class InstructorsController : Controller
    {
        private readonly WebsiteContext _context;
        private readonly string _connectionString;

        public InstructorsController(WebsiteContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        // GET: Instructors
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Instructors.Include(i => i.InstructorNavigation);
            return View(await websiteContext.ToListAsync());
        }

        public async Task<IActionResult> GetCourses(int id)
        {
            var courses = new List<Course>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetCoursesByInstructor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@InstructorID", id));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var course = new Course
                            {
                                Cid = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                LearningObjective = reader.GetString(2),
                                CreditPoints = reader.GetInt32(3),
                                DifficultyLevel = reader.GetString(4),
                                Description = reader.GetString(5)
                            };
                            courses.Add(course);
                        }
                    }
                }
            }

            return View(courses);
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


        public async Task<IActionResult> GetLearnersByCourse(int courseId)
        {
            var learners = new List<Learner>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("LearnersCourses", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CourseID", courseId);

                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            learners.Add(new Learner
                            {
                                Sid = reader.GetInt32(0),
                                Fname = reader.GetString(1),
                                Lname = reader.GetString(2),
                                Country = reader.GetString(3),
                               
                            });
                        }
                    }
                }
            }

            return View(learners);
        }
    

    [HttpGet]
        public IActionResult CreateNewActivity(int moduleId, int courseId)
        {
            var model = new LearningActivity
            {
                ModuleId = moduleId,
                Cid = courseId
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewActivity(int ActivityId,int ModuleId,int Cid,string ActivityType, string Instruction,int MaxPoints)
        {
            if (ModelState.IsValid)
            {
                
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        await connection.OpenAsync();
                        using (var command = new SqlCommand("CreateNewActivity", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("@ActivityId", ActivityId));
                            command.Parameters.Add(new SqlParameter("@ModuleId",ModuleId));
                            command.Parameters.Add(new SqlParameter("@Cid", Cid));
                            command.Parameters.Add(new SqlParameter("@ActivityType", ActivityType));
                            command.Parameters.Add(new SqlParameter("@Instruction", Instruction));
                            command.Parameters.Add(new SqlParameter("@MaxPoints", MaxPoints));

                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    return RedirectToAction("GetModules", new { id = ModuleId});
                }
               
   
            return View();
        }

        
        public async Task<IActionResult> GetAssessments(int moduleId, int courseId)
        {
            var assessments = new List<Assessment>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetAssessmentsByModuleAndCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ModuleID", moduleId));
                    command.Parameters.Add(new SqlParameter("@CourseID", courseId));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var assessment = new Assessment
                            {
                                AssessmentId = reader.GetInt32(0),
                                ModuleId = reader.GetInt32(1),
                                Cid = reader.GetInt32(2),
                                Type = reader.GetString(3),
                                TotalMarks = reader.GetInt32(4),
                                PassingMarks = reader.GetInt32(5),
                                Weightage = reader.GetInt32(6),
                                Criteria = reader.GetString(7),
                                Description = reader.GetString(8),
                                Title = reader.GetString(9)
                            };
                            assessments.Add(assessment);
                        }
                    }
                }
            }

            return View(assessments);
        }


    [HttpGet]
        public IActionResult CreateAssessment(int moduleId, int courseId)
        {
            var model = new Assessment
            {
                ModuleId = moduleId,
                Cid = courseId
            };
            return View(model);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> CreateAssessment(int ModuleId, int Cid, int AssessmentId, string Type, int TotalMarks, int PassingMarks, int Weightage, string Criteria, string Description, string Title)
        {
            if (ModelState.IsValid)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("CreateAssessmentbyModuleAndCourse", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ModuleID", ModuleId));
                        command.Parameters.Add(new SqlParameter("@CourseID", Cid));
                        command.Parameters.Add(new SqlParameter("@AssessmentID", AssessmentId));
                        command.Parameters.Add(new SqlParameter("@Type", Type));
                        command.Parameters.Add(new SqlParameter("@TotalMarks", TotalMarks));
                        command.Parameters.Add(new SqlParameter("@PassingMarks", PassingMarks));
                        command.Parameters.Add(new SqlParameter("@Weightage", Weightage));
                        command.Parameters.Add(new SqlParameter("@Criteria", Criteria));
                        command.Parameters.Add(new SqlParameter("@Description", Description));
                        command.Parameters.Add(new SqlParameter("@Title", Title));

                        await command.ExecuteNonQueryAsync();
                    }
                }
                return RedirectToAction("GetModules", new { id = Cid });
            }
            return View();
        }
        public async Task<IActionResult> GetAllAssessments( int cid)
        {
            var assessments = new List<Assessment>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetAllAssessments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Cid", cid));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var assessment = new Assessment
                            {
                                AssessmentId = reader.GetInt32(reader.GetOrdinal("assessment_id")),
                                ModuleId = reader.GetInt32(reader.GetOrdinal("module_id")),
                                Cid = reader.GetInt32(reader.GetOrdinal("cid")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Type = reader.GetString(reader.GetOrdinal("type")),
                                TotalMarks = reader.GetInt32(reader.GetOrdinal("total_marks")),
                                PassingMarks = reader.GetInt32(reader.GetOrdinal("passing_marks")),
                                Weightage = reader.GetInt32(reader.GetOrdinal("weightage")),
                                Criteria = reader.GetString(reader.GetOrdinal("criteria")),
                                Description = reader.GetString(reader.GetOrdinal("description"))
                            };
                            assessments.Add(assessment);
                        }
                    }
                }
            }

            return View(assessments);
        }


        public async Task<IActionResult> SendNotification(int? assessmentId)
        {
            if (assessmentId == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Module)
                .FirstOrDefaultAsync(a => a.AssessmentId == assessmentId);

            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        
      
        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var instructor = await _context.Instructors
                    .Include(i => i.InstructorNavigation)
                    .FirstOrDefaultAsync(m => m.InstructorId == id);
                if (instructor == null)
                {
                    return NotFound();
                }

                return View(instructor);
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendNotification(int learnerId, string message , string Urgency)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SendNotificationToLearner", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@LearnerID", learnerId));
                    command.Parameters.Add(new SqlParameter("@Message", message));
                    command.Parameters.Add(new SqlParameter("@Urgency", Urgency));

                    await command.ExecuteNonQueryAsync();
                }
            }

            return RedirectToAction("GetLearnerScores");
        }
        // GET: Instructors/Create
        public IActionResult Create()
            {
                ViewData["InstructorId"] = new SelectList(_context.Users, "Id", "Id");
                return View();
            }

            // POST: Instructors/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("InstructorId,Name,LatestQualification,ExpertiseArea")] Instructor instructor)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instructor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["InstructorId"] = new SelectList(_context.Users, "Id", "Id", instructor.InstructorId);
                return View(instructor);
            }

            // GET: Instructors/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var instructor = await _context.Instructors.FindAsync(id);
                if (instructor == null)
                {
                    return NotFound();
                }
                ViewData["InstructorId"] = new SelectList(_context.Users, "Id", "Id", instructor.InstructorId);
                return View(instructor);
            }

            // POST: Instructors/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("InstructorId,Name,LatestQualification,ExpertiseArea")] Instructor instructor)
            {
                if (id != instructor.InstructorId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(instructor);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!InstructorExists(instructor.InstructorId))
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
                ViewData["InstructorId"] = new SelectList(_context.Users, "Id", "Id", instructor.InstructorId);
                return View(instructor);
            }

        // GET: Instructors/Delete/5
       

        public async Task<IActionResult> GetLearnerScores(int assessmentId)
        {
            ViewBag.AssessmentId = assessmentId;
            var learnerScores = new List<(int Sid, int ScoredPoints)>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetLearnerScoresByAssessment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@AssessmentID", assessmentId));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var sid = reader.GetInt32(0);
                            var scoredPoints = reader.GetInt32(1);
                            learnerScores.Add((sid, scoredPoints));
                        }
                    }
                }
            }

            return View(learnerScores);
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



        [HttpPost]
        public async Task<IActionResult> UpdateLearnerScore(int learnerId, int assessmentId, int score)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GradeUpdate", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@LearnerID", learnerId));
                    command.Parameters.Add(new SqlParameter("@AssessmentID", assessmentId));
                    command.Parameters.Add(new SqlParameter("@score", score));

                    await command.ExecuteNonQueryAsync();
                }
            }

            return RedirectToAction("GetLearnerScores", new { assessmentId = assessmentId });
        }



        // GET: Instructors/Delete/5
        // GET: Instructors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(GetCourses), new { id = course.Cid });
        }


        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.InstructorId == id);
        }
    }
}

