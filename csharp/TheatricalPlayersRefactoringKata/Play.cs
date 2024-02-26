using System;

namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        public string Name { get; private set; }
        public abstract PlayType Type { get;}

        public Play(string name) {
            Name = name;
        }

        public abstract int CalculateAmount(int performanceAudience);

        public abstract int CalculateOwnedCreditsByAudienceVolume(Performance performance);
    }
}
    