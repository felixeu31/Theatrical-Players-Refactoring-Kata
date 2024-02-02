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
                var performanceAmount = CalculatePerformanceAmount(performance, play);
                volumeCredits += CalculateVolumeCredits(performance, play);
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

        private static int CalculateVolumeCredits(Performance performance, Play play)
        {
            var volumeCredits = Math.Max(performance.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == play.Type) volumeCredits += (int)Math.Floor((decimal)performance.Audience / 5);
            return volumeCredits;
        }

        private static decimal CalculatePerformanceAmount(Performance performance, Play play)
        {
            var performanceAmount = 0;
            switch (play.Type)
            {
                case "tragedy":
                    performanceAmount = 40000;
                    if (performance.Audience > 30)
                    {
                        performanceAmount += 1000 * (performance.Audience - 30);
                    }

                    break;
                case "comedy":
                    performanceAmount = 30000;
                    if (performance.Audience > 20)
                    {
                        performanceAmount += 10000 + 500 * (performance.Audience - 20);
                    }

                    performanceAmount += 300 * performance.Audience;
                    break;
                default:
                    throw new Exception("unknown type: " + play.Type);
            }
            
            return Convert.ToDecimal(performanceAmount / 100);
        }
    }
}
