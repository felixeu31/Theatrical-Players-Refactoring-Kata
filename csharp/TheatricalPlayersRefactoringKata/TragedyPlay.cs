namespace TheatricalPlayersRefactoringKata;

public record TragedyPlay(string Name) : IPlay
{
    public string Type => "tragedy";
}