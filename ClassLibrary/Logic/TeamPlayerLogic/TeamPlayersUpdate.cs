namespace ClassLibrary.Logic.TeamPlayerLogic
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class TeamPlayersUpdate : ITeamPlayersUpdate
    {
        public int? TeamPlayersUpdateTransaction(TeamPlayer teamPlayer)
        {
            int? TeamPlayersID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(teamPlayer).State = EntityState.Modified;
                    context.SaveChanges();
                    TeamPlayersID = teamPlayer.TeamPlayerID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TeamPlayersID;
        }
    }
}
