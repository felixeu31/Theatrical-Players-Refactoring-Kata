using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests
{
    public class StatementPrinterTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void PrintStatement_WithSeveralValidPerformances_PrintsExpectedStatement()
        {
            var plays = new Dictionary<string, Play>();
            plays.Add("hamlet", new Tragedy("Hamlet"));
            plays.Add("as-like", new Comedy("As You Like It"));
            plays.Add("othello", new Tragedy("Othello"));

            Invoice invoice = new Invoice("BigCo", new List<Performance>{new Performance("hamlet", 55),
                new Performance("as-like", 35),
                new Performance("othello", 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice, plays);

            Approvals.Verify(result);
        }
    }
}
