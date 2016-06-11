using System;

namespace Wrox.ProCSharp.LINQ
{
    [Serializable]
    public class Team
    {
        public Team(string name, params int[] years)
        {
            this.Name = name;
            this.Years = years;
        }
        public string Name { get; private set; }
        public int[] Years { get; private set; }
    }
}
