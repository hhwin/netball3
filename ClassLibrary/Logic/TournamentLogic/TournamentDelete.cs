
namespace ClassLibrary.Logic.Tournament
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    /// <summary>
    /// Deletes a given Tournament object. 
    /// </summary>
    /// <param name="Tournament"></param> 
    public class TournamentDelete : ITournamentDelete
    {
        public void TournamentRemove(Tournament tournament)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(tournament).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
