using SULS.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemDetails
    {
        public IEnumerable<SubmissonInfo> Submissions { get; set; }
        public string ProblemId { get; set; }
        public string Name { get; set; }
        public int MaxPoints { get; set; }
    }
}
