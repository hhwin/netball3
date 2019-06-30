namespace ClassLibrary.Logic.Tournament
{
    public interface ITournamentUpdate
    {
        int? TournamentUpdateTransaction(Database.Tournament tournament);
    }
}