
namespace ClassLibrary.Logic.Tournament
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class TournamentInsert : ITournamentInsert
    {
        /// <summary>
        /// Insert a Tournament object in Tournament table returning TournamentID if successful.
        /// TournamentID = null if failed.
        /// </summary>
        /// <param name="Tournament"></param>
        /// <returns></returns>
        public int? TournamentAdd(Tournament tournament)
        {
            int? tournamentID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(tournament).State = EntityState.Added;
                    context.SaveChanges();
                    tournamentID = tournament.TournamentID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tournamentID;
        }
    }
}
