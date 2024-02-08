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
        return new Invoice(customer, performances, _plays);
    }
}