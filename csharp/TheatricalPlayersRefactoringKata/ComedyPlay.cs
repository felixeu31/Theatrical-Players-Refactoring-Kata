namespace TheatricalPlayersRefactoringKata;

public record ComedyPlay(string Name) : IPlay
{
    public string Type => "comedy";
}