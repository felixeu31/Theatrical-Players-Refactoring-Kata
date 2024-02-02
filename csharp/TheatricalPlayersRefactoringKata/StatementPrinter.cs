using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        private readonly CultureInfo _cultureInfo;

        public StatementPrinter()
        {
            _cultureInfo = new CultureInfo("en-US");
        }

        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            var totalAmount = 0M;
            var volumeCredits = 0;
            var statement = GetStatementHeader(invoice);

            foreach(var performance in invoice.Performances) 
            {
                var play = plays[performance.PlayID];
                var performanceAmount = play.CalculatePerformanceAmount(performance.Audience);
                volumeCredits += play.CalculateVolumeCredits(performance.Audience);
                totalAmount += performanceAmount;

                // print line for this order
                statement += GetPerformanceLine(play, performanceAmount, performance);
            }
            statement += GetOwedAmountLine(totalAmount);
            statement += GetCreditsLine(volumeCredits);
            return statement;
        }

        private static string GetStatementHeader(Invoice invoice)
        {
            return $"Statement for {invoice.Customer}\n";
        }

        private static string GetCreditsLine(int volumeCredits)
        {
            return String.Format("You earned {0} credits\n", volumeCredits);
        }

        private string GetOwedAmountLine(decimal totalAmount)
        {
            return String.Format(_cultureInfo, "Amount owed is {0:C}\n", totalAmount);
        }

        private string GetPerformanceLine(Play play, decimal performanceAmount, Performance performance)
        {
            return String.Format(_cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, performanceAmount, performance.Audience);
        }
    }
}
