namespace ClassLibrary.Logic.Tournament
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class TournamentUpdate : ITournamentUpdate
    {
        public int? TournamentUpdateTransaction(Tournament tournament)
        {
            int? tournamentID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(tournament).State = EntityState.Modified;
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
