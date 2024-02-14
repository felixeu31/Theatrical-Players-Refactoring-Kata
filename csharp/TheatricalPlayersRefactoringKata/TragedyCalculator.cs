using System;

namespace TheatricalPlayersRefactoringKata;

public class TragedyCalculator : PlayCalculator
{
    private readonly Performance _performance;
    private readonly int _volumeThreshold = 30;
    private readonly decimal _baseAmount = 400;
    private readonly int _extraAmountPerExceedAssistant = 10;

    public TragedyCalculator(Performance performance) : base (performance, 30, 400, 10)
    {
        _performance = performance;
    }
}