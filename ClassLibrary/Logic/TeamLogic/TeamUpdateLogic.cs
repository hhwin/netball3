
namespace ClassLibrary.Logic.Team
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    /// <summary>
    /// Update team object.
    /// </summary>
    public class TeamUpdateLogic : ITeamUpdateLogic
    {
        public int? TeamUpdateTransaction(Team team)
        {
            int? teamID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(team).State = EntityState.Modified;
                    context.SaveChanges();
                    teamID = team.TeamID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamID;
        }
    }
}
