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
            var totalAmount = 0;
            var ownedCreditsByAudienceVolume = 0;
            var printedStatement = string.Format("Statement for {0}\n", invoice.Customer);

            foreach(var performance in invoice.Performances) 
            {   
                var play = plays[performance.PlayID];

                var performanceAmount = play.CalculateAmount(performance.Audience);

                // Owned Credits
                ownedCreditsByAudienceVolume += Math.Max(performance.Audience - 30, 0);
                // add extra credit for every ten comedy attendees
                if ("comedy" == play.Type) ownedCreditsByAudienceVolume += (int)Math.Floor((decimal)performance.Audience / 5);

                // print line for this order
                printedStatement += String.Format(_cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(performanceAmount / 100), performance.Audience);
                totalAmount += performanceAmount;
            }
            printedStatement += String.Format(_cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
            printedStatement += String.Format("You earned {0} credits\n", ownedCreditsByAudienceVolume);
            return printedStatement;
        }
    }
}
