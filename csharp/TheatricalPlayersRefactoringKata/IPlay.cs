using System;

namespace TheatricalPlayersRefactoringKata
{
    public interface IPlay
    {
        string Name { get; }
        PlayType Type { get; }

        int CalculateAmount(int performanceAudience);

        int CalculateOwnedCreditsByAudienceVolume(Performance performance);
    }
}
    