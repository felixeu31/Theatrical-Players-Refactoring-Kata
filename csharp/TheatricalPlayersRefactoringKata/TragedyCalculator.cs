using System;

namespace TheatricalPlayersRefactoringKata;

public class TragedyCalculator : IPerformanceCalculator
{
    private readonly Performance _performance;
    private readonly int _volumeThreshold = 30;
    private readonly decimal _baseAmount = 400;
    private readonly int _extraAmountPerExceedAssistant = 10;

    public TragedyCalculator(Performance performance)
    {
        _performance = performance;
    }
    public decimal CalculateAmount()
    {
        if (!AudienceExceedVolumeThreshold())
        {
            return _baseAmount;
        }
        return _baseAmount + _extraAmountPerExceedAssistant * ExceededAudience();
    }

    private int ExceededAudience()
    {
        return _performance.Audience - _volumeThreshold;
    }

    private bool AudienceExceedVolumeThreshold()
    {
        return _performance.Audience > _volumeThreshold;
    }

    public int CalculateVolumeCredits()
    {
        var volumeCredits = Math.Max(_performance.Audience - 30, 0);
        return volumeCredits;
    }
}