using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatricalPlayersRefactoringKata
{
    public class ComedyPlay : IPlay
    {
        public string Name { get; }
        public string Type => "comedy";

        public ComedyPlay(string name)
        {
            Name = name;
        }
    }
}
