using ClassLibrary.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public class TeamPlayersDelete : ITeamPlayersDelete
    {
        public void TeamPlayersRemove(TeamPlayer teamPlayer)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(teamPlayer).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void TeamPlayersRemove(int playerID,
            int teamID)
        {
            TeamPlayer teamPlayer = new TeamPlayer();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    teamPlayer = context.TeamPlayers
                        .Where(t => t.TeamID == teamID && t.PlayerID == playerID)
                        .FirstOrDefault();

                    if (teamPlayer != null)
                    {
                        context.Entry(teamPlayer).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Cannot delete team player object with teamID " + teamID.ToString() + " and playerID " + playerID.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}