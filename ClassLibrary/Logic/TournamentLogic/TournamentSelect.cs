namespace ClassLibrary.Logic.Tournament
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;

    /// <summary>
    /// Get tournament details including person details.
    /// </summary>
    public class TournamentSelect : ITournamentSelect
    {
        public Tournament GetTournament(int tournamentID)
        {
            Tournament tournament = new Tournament();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    tournament = context.Tournaments
                        .Where(c => c.TournamentID == tournamentID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tournament;
        }

        public IList<Tournament> GetTournamentList()
        {
            IList<Tournament> tournamentList = new List<Tournament>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    tournamentList = context.Tournaments
                        .AsNoTracking()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tournamentList;
        }
    }
}
