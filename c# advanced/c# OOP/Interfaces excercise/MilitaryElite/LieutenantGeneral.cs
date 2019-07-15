using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<Private> privates;

        IReadOnlyCollection<Private> ILieutenantGeneral.Privates { get => privates; }

        public LieutenantGeneral(string id, string firstName, string lastName, double salary, params Private[] AddPriv) : base(id, firstName, lastName, salary)
        {
            privates.AddRange(AddPriv);
        }
    }
}
