using System.Collections.Generic;
using System.Linq;

namespace TheatricalPlayersRefactoringKata
{
    public class Invoice
    {
        private readonly string _customer;
        private readonly List<Performance> _performances;
        private readonly Dictionary<string, Play> _plays;

        public Invoice(string customer, List<Performance> performance, Dictionary<string, Play> plays)
        {
            this._customer = customer;
            this._performances = performance;
            _plays = plays;
        }

        public string Customer => _customer;

        public IEnumerable<InvoiceItem> InvoiceItems()
        {
            foreach (var performance in _performances)
            {
                var play = _plays[performance.PlayID];
                yield return new InvoiceItem(play.Name, play.CalculatePerformanceAmount(performance.Audience),
                    performance.Audience);
            }
        }

        public decimal VolumeCredits()
        {
            decimal volumeCredits = 0;
            foreach (var performance in _performances)
            {
                var play = _plays[performance.PlayID];
                volumeCredits += play.CalculateVolumeCredits(performance.Audience);
            }

            return volumeCredits;
        }

        public decimal TotalAmount()
        {
            return InvoiceItems().Sum(x => x.Amount);
        }
    }

    public class InvoiceItem
    {
        public string Name { get; }
        public decimal Amount { get; }
        public int Audience { get; }

        public InvoiceItem(string name, decimal amount, int audience)
        {
            Name = name;
            Amount = amount;
            Audience = audience;
        }
    }
}
