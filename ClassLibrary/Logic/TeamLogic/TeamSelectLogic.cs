using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Database;
using System;

namespace ClassLibrary.Logic.Team
{

    /// <summary>
    /// Get team details including person details.
    /// </summary>
    public class TeamSelectLogic : ITeamSelectLogic
    {
        public Database.Team GetTeam(int teamID)
        {
            Database.Team team = new Database.Team();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    team = context.Teams
                        .Where(c => c.TeamID == teamID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return team;
        }
        public Database.Team GetTeam(string teamName)
        {
            Database.Team team = new Database.Team();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    team = context.Teams
                        .Where(c => c.TeamName.Trim().ToLower() == teamName.Trim().ToLower())
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return team;
        }

        public IList<Database.Team> GetTeamList()
        {
            IList<Database.Team> teamList = new List<Database.Team>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    teamList = context.Teams
                        .AsNoTracking()
                        .OrderBy(t => t.TeamName)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamList;
        }
    }
}
