using System;

namespace TheatricalPlayersRefactoringKata;

public static class PerformanceCalculatorFactory
{
    public static IPerformanceCalculator Create(Performance performance, IPlay play)
    {
        switch (play.Type)
        {
            case "tragedy":
                return new TragedyCalculator(performance);
            case "comedy":
                return new ComedyCalculator(performance);
            default:
                throw new Exception("unknown type: " + play.Type);
        }
    }
}