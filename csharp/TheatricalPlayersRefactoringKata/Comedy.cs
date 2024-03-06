using System;


namespace TheatricalPlayersRefactoringKata
{
    public class Comedy : IPlay
    {
        public string Name { get; }

        public Comedy(string name)
        {
            Name = name;
        }
        public int CalculateAmount(int performanceAudience)
        {
            var dramaPerformanceAmount = 30000;
            if (performanceAudience > 20)
            {
                dramaPerformanceAmount += 10000 + 500 * (performanceAudience - 20);
            }
            dramaPerformanceAmount += 300 * performanceAudience;

            return dramaPerformanceAmount;
        }

        public int CalculateOwnedCreditsByAudienceVolume(Performance performance)
        {
            int ownedCreditsByAudienceVolume = Math.Max(performance.Audience - 30, 0);
            
            // add extra credit for every ten comedy attendees
            ownedCreditsByAudienceVolume += (int)Math.Floor((decimal)performance.Audience / 5);

            return ownedCreditsByAudienceVolume;
        }
    }
}
