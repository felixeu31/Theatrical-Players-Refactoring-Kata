using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

public class Theater
{
    private Dictionary<string, IPlay> _plays = new();

    public Theater WithTragedy(string key, string name)
    {
        _plays.Add(key, new TragedyPlay(name));
        return this;
    }
    public Theater WithComedy(string key, string name)
    {
        _plays.Add(key, new ComedyPlay(name));
        return this;
    }

    public Invoice GenerateInvoice(string customer, List<Performance> performances)
    {
        var invoice = new Invoice(customer);

        foreach (var performance in performances)
        {
            invoice.WithPerformance(performance, _plays[performance.PlayID]);
        }

        return invoice;
    }
}