using System;

namespace TheatricalPlayersRefactoringKata
{
    internal class Tragedy : Play
    {
        public override string Type => "tragedy";

        public Tragedy(string name) : base(name) {}
        public override int CalculateAmount(int performanceAudience)
        {
            int tragedyPerformanceAmount = 40000;
            if (performanceAudience > 30)
            {
                tragedyPerformanceAmount += 1000 * (performanceAudience - 30);
            }
            return tragedyPerformanceAmount;
        }
    }
}
    