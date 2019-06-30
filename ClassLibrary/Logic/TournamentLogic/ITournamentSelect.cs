using System.Collections.Generic;

namespace ClassLibrary.Logic.Tournament
{
    public interface ITournamentSelect
    {
        Database.Tournament GetTournament(int tournamentID);
        IList<Database.Tournament> GetTournamentList();
    }
}