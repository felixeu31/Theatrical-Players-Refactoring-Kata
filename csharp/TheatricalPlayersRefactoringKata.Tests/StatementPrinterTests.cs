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
        public void test_statement_example()
        {
            var theater = new Theater()
                .WithTragedy("hamlet", "Hamlet")
                .WithComedy("as-like", "As You Like It")
                .WithTragedy("othello", "Othello");

            Invoice invoice = theater.GenerateInvoice("BigCo", new List<Performance>{new("hamlet", 55),
                new("as-like", 35),
                new("othello", 40)});
            
            StatementPrinter statementPrinter = new StatementPrinter();
            var result = statementPrinter.Print(invoice);

            Approvals.Verify(result);
        }
    }
}
