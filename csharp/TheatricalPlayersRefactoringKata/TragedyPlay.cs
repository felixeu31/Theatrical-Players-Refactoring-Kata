using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class TragedyPlay : IPlay
    {
        public string Name { get; }
        public string Type => "tragedy";

        public TragedyPlay(string name)
        {
            Name = name;
        }
    }
}
