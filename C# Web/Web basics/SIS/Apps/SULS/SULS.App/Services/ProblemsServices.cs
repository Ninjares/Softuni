using SULS.App.Models;
using SULS.App.ViewModels.Problems;
using SULS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.App.Services
{
    public class ProblemsServices : IProblemServices
    {
        private readonly SULSContext db;
        public ProblemsServices(SULSContext db)
        {
            this.db = db;
        }
        public void Create(string name, int maxPoints)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = maxPoints
            };
            db.Problems.Add(problem);
            db.SaveChanges();
        }

        public IEnumerable<Problem> GetAllProblems()
        {
            return db.Problems.ToArray();
        }

        public string GetNameFor(string problemId)
        {
            return db.Problems.FirstOrDefault(x => x.Id == problemId).Name;
        }

        public IEnumerable<SubmissonInfo> GetSubmissionsFor(string problemId)
        {
            return db.Submissions.Where(x => x.ProblemId == problemId).Select(x => new SubmissonInfo
            {
                AchievedResult = x.AchievedResult,
                CreatedOn = x.CreatedOn.ToString("HH:mm dd/M/yyyy"),
                SubmissionId = x.Id,
                Username = x.User.Username
            }).ToArray();
        }

        public int MaxPointsFor(string problemId)
        {
            var problem = db.Problems.FirstOrDefault(x => x.Id == problemId);
            return problem.Points;

        }

        public bool NameUsed(string name)
        {
            return db.Problems.Any(x => x.Name == name);
        }

        public bool ProblemExists(string id)
        {
            return db.Problems.Any(x => x.Id==id);
        }
    }
}
