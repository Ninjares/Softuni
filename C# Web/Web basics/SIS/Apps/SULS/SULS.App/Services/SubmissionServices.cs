using SULS.App.Models;
using SULS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.App.Services
{
    public class SubmissionServices : ISubmissonServices
    {
        private readonly SULSContext db;
        public SubmissionServices(SULSContext db)
        {
            this.db = db;
        }
        public void Create(string problemId, string userId, string code)
        {
            Random rnd = new Random();
            var submission = new Submission()
            {
                ProblemId = problemId,
                UserId = userId,
                Code = code,
                AchievedResult = rnd.Next(0, db.Problems.Find(problemId).Points),
                CreatedOn = DateTime.UtcNow
            };
            db.Submissions.Add(submission);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submissiontodelete = db.Submissions.Find(id);
            db.Submissions.Remove(submissiontodelete);
            db.SaveChanges();
        }

        public string GetProblemId(string submissionId)
        {
            return db.Submissions.FirstOrDefault(x => x.Id == submissionId).ProblemId;
        }

        public string GetProblemName(string Id)
        {
            var problem = db.Problems.FirstOrDefault(x => x.Id == Id);
            if (problem == null) return "No such problem";
            return problem.Name;
        }

        public bool ProblemExists(string id)
        {
            return db.Problems.Any(x => x.Id == id);
        }

        public bool SubmissionExists(string id)
        {
            return db.Submissions.Any(x => x.Id==id);
        }
    }
}
