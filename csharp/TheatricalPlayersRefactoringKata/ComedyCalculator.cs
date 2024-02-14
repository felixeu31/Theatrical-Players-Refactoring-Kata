using System;

namespace TheatricalPlayersRefactoringKata;

public class ComedyCalculator : PlayCalculator
{
    private readonly Performance _performance;

    public ComedyCalculator(Performance performance) : base(performance, 20, 400, 5)
    {
        _performance = performance;
    }

    public override decimal CalculateAmount()
    {
        return base.CalculateAmount() + 3 * _performance.Audience;
    }

    public override int CalculateVolumeCredits()
    {
        return base.CalculateVolumeCredits() + (int)Math.Floor((decimal)_performance.Audience / 5);
    }
}