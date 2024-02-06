using System;

namespace TheatricalPlayersRefactoringKata;

public class TragedyCalculator : IPerformanceCalculator
{
    private readonly Performance _performance;

    public TragedyCalculator(Performance performance)
    {
        _performance = performance;
    }
    public decimal CalculateAmount()
    {
        decimal performanceAmount = 40000;
        if (_performance.Audience > 30)
        {
            performanceAmount += 1000 * (_performance.Audience - 30);
        }
        return Convert.ToDecimal(performanceAmount / 100);
    }

    public int CalculateVolumeCredits()
    {
        var volumeCredits = Math.Max(_performance.Audience - 30, 0);
        return volumeCredits;
    }
}