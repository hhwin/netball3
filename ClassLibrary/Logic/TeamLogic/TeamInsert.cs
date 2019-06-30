
namespace ClassLibrary.Logic.Team
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class TeamInsert : ITeamInsert
    {
        /// <summary>
        /// Insert a Team object in Team table returning TeamID if successful.
        /// TeamID = null if failed.
        /// </summary>
        /// <param name="Team"></param>
        /// <returns></returns>
        public int? TeamAdd(Team team)
        {
            int? teamID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(team).State = EntityState.Added;
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
