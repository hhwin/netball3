namespace ClassLibrary.Logic.TeamPlayerLogic
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class TeamPlayersInsert : ITeamPlayersInsert
    {
        public void TeamPlayerInsert(TeamPlayer teamPlayer)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(teamPlayer).State = EntityState.Added;
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
