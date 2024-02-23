namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        public string Name { get; private set; }
        public abstract string Type { get;}

        public Play(string name) {
            Name = name;
        }

        public abstract int CalculateAmount(int performanceAudience);
    }
}
    