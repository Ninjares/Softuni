using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces_and_abstraction
{
    public interface IEducatable
    {
        string FacultyNumber { get; set; }
    }
    class Student : Person, IEducatable //class must always be first
    {
        public string FacultyNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
