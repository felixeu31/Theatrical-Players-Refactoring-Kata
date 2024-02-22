using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata
{
    public class StatementPrinter
    {
        public string Print(Invoice invoice, Dictionary<string, Play> plays)
        {
            var totalAmount = 0;
            var ownedCreditsByAudienceVolume = 0;
            var printedStatement = string.Format("Statement for {0}\n", invoice.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach(var performance in invoice.Performances) 
            {
                var play = plays[performance.PlayID];
                var performanceAmount = 0;
                switch (play.Type) 
                {
                    case "tragedy":
                        performanceAmount = 40000;
                        if (performance.Audience > 30) {
                            performanceAmount += 1000 * (performance.Audience - 30);
                        }
                        break;
                    case "comedy":
                        performanceAmount = 30000;
                        if (performance.Audience > 20) {
                            performanceAmount += 10000 + 500 * (performance.Audience - 20);
                        }
                        performanceAmount += 300 * performance.Audience;
                        break;
                    default:
                        throw new Exception("unknown type: " + play.Type);
                }
                // Owned Credits
                ownedCreditsByAudienceVolume += Math.Max(performance.Audience - 30, 0);
                // add extra credit for every ten comedy attendees
                if ("comedy" == play.Type) ownedCreditsByAudienceVolume += (int)Math.Floor((decimal)performance.Audience / 5);

                // print line for this order
                printedStatement += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(performanceAmount / 100), performance.Audience);
                totalAmount += performanceAmount;
            }
            printedStatement += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
            printedStatement += String.Format("You earned {0} credits\n", ownedCreditsByAudienceVolume);
            return printedStatement;
        }
    }
}
