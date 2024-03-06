using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Tragedy : IPlay
    {
        public string Name { get;}

        public Tragedy(string name)
        {
            Name = name;
        }
        public int CalculateAmount(int performanceAudience)
        {
            int tragedyPerformanceAmount = 40000;
            if (performanceAudience > 30)
            {
                tragedyPerformanceAmount += 1000 * (performanceAudience - 30);
            }
            return tragedyPerformanceAmount;
        }

        public int CalculateOwnedCreditsByAudienceVolume(Performance performance)
        {
            int ownedCreditsByAudienceVolume = Math.Max(performance.Audience - 30, 0);

            return ownedCreditsByAudienceVolume;
        }
    }
}
    