namespace TheatricalPlayersRefactoringKata;

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