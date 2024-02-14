using System;

namespace TheatricalPlayersRefactoringKata;

public class TragedyCalculator : PlayCalculator
{
    public TragedyCalculator(Performance performance) : base (performance, 30, 400, 10)
    {
    }
}