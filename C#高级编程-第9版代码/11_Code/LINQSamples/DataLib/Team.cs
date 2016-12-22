using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.LINQ
{
    [Serializable]
    public class Team
    {
        public Team(string name, params int[] years)
        {
            this.Name = name;
            this.Years = new List<int>(years);
        }
        public string Name { get; private set; }
        public IEnumerable<int> Years { get; private set; }
    }
}
