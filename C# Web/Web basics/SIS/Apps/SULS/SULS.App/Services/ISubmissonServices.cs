using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.Services
{
    public interface ISubmissonServices
    {
        void Create(string ProblemId, string UserId, string code);
        string GetProblemName(string Id);
        string GetProblemId(string submissionId);
        void Delete(string id);
        bool ProblemExists(string id);
        bool SubmissionExists(string id);
    }
}
