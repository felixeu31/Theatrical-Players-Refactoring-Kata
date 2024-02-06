using System;

namespace TheatricalPlayersRefactoringKata;

public class ComedyCalculator : IPerformanceCalculator
{
    private readonly Performance _performance;

    public ComedyCalculator(Performance performance)
    {
        _performance = performance;
    }

    public decimal CalculateAmount()
    {
        decimal performanceAmount = 30000;

        if (_performance.Audience > 20)
        {
            performanceAmount += 10000 + 500 * (_performance.Audience - 20);
        }
        performanceAmount += 300 * _performance.Audience;

        return Convert.ToDecimal(performanceAmount / 100);
    }

    public int CalculateVolumeCredits()
    {

        var volumeCredits = Math.Max(_performance.Audience - 30, 0);
        volumeCredits += (int)Math.Floor((decimal)_performance.Audience / 5);
        return volumeCredits;
    }
}