using System.Collections.Generic;
using System.Linq;

namespace TheatricalPlayersRefactoringKata
{
    public class Invoice
    {
        private List<InvoiceItem> _items;
        private int _volumeCredits;
        private decimal _totalAmount;

        public Invoice(string customer)
        {
            this.Customer = customer;
            _volumeCredits = 0;
            _totalAmount = 0;
            _items = new List<InvoiceItem>();
        }

        public string Customer { get; }

        public int VolumeCredits => _volumeCredits;

        public decimal TotalAmount => _totalAmount;

        public IReadOnlyList<InvoiceItem> InvoiceItems => _items;

        public Invoice WithPerformance(Performance performance, IPlay play)
        {
            var calculator = PerformanceCalculatorFactory.Create(performance, play);
            var invoiceItem = new InvoiceItem(play.Name, calculator.CalculateAmount(),
                performance.Audience);

            _items.Add(invoiceItem);
            _volumeCredits += calculator.CalculateVolumeCredits();
            _totalAmount += invoiceItem.Amount;
            return this;
        }
    }
}
