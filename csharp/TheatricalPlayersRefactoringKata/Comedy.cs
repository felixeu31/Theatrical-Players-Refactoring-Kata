using System;


namespace TheatricalPlayersRefactoringKata
{
    public class Comedy : Play
    {
        public override PlayType Type => PlayType.Comedy;

        public Comedy(string name) : base(name) {}
        public override int CalculateAmount(int performanceAudience)
        {
            var dramaPerformanceAmount = 30000;
            if (performanceAudience > 20)
            {
                dramaPerformanceAmount += 10000 + 500 * (performanceAudience - 20);
            }
            dramaPerformanceAmount += 300 * performanceAudience;

            return dramaPerformanceAmount;
        }

        public override int CalculateOwnedCreditsByAudienceVolume(Performance performance)
        {
            int ownedCreditsByAudienceVolume = Math.Max(performance.Audience - 30, 0);
            
            // add extra credit for every ten comedy attendees
            ownedCreditsByAudienceVolume += (int)Math.Floor((decimal)performance.Audience / 5);

            return ownedCreditsByAudienceVolume;
        }
    }
}
