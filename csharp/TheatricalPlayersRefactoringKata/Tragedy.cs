using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Tragedy : Play
    {
        public override PlayType Type => PlayType.Tragedy;

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

        public override int CalculateOwnedCreditsByAudienceVolume(Performance performance)
        {
            int ownedCreditsByAudienceVolume = Math.Max(performance.Audience - 30, 0);

            return ownedCreditsByAudienceVolume;
        }
    }
}
    