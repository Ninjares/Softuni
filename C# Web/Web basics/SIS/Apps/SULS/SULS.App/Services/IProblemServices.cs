using SULS.App.Models;
using SULS.App.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Services
{
    public interface IProblemServices
    {
        void Create(string name, int maxPoints);
        IEnumerable<Problem> GetAllProblems();
        bool NameUsed(string name);
        IEnumerable<SubmissonInfo> GetSubmissionsFor(string problemId);
        int MaxPointsFor(string problemId);
        string GetNameFor(string problemId);
        bool ProblemExists(string id);
        
    }
}
