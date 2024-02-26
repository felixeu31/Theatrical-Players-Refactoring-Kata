using System;


namespace TheatricalPlayersRefactoringKata
{
    public class Comedy : Play
    {
        public override string Type => "comedy";

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
    }
}
