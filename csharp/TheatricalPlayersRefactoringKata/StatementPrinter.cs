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

        public string Print(Invoice invoice)
        {
            var statement = GetStatementHeader(invoice);

            foreach(var invoiceItem in invoice.InvoiceItems) 
            {
                statement += GetPerformanceLine(invoiceItem);
            }
            statement += GetOwedAmountLine(invoice.TotalAmount);
            statement += GetCreditsLine(invoice.VolumeCredits);
            return statement;
        }

        private static string GetStatementHeader(Invoice invoice)
        {
            return $"Statement for {invoice.Customer}\n";
        }

        private static string GetCreditsLine(decimal volumeCredits)
        {
            return $"You earned {volumeCredits} credits\n";
        }

        private string GetOwedAmountLine(decimal totalAmount)
        {
            return String.Format(_cultureInfo, "Amount owed is {0:C}\n", totalAmount);
        }

        private string GetPerformanceLine(InvoiceItem invoiceItem)
        {
            return String.Format(_cultureInfo, "  {0}: {1:C} ({2} seats)\n", invoiceItem.Name, invoiceItem.Amount, invoiceItem.Audience);
        }
    }
}
