using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;
using ClassLibrary.Database;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    /// <summary>
    /// Get TeamPlayer details including person details.
    /// </summary>
    public class TeamPlayersSelect : ITeamPlayersSelect
    {
        public TeamPlayer GetTeamPlayer(int TeamPlayerID)
        {
            TeamPlayer TeamPlayer = new TeamPlayer();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    TeamPlayer = context.TeamPlayers
                        .AsNoTracking()
                        .Where(c => c.TeamPlayerID == TeamPlayerID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TeamPlayer;
        }

        public IList<TeamPlayer> GetTeamPlayerList()
        {
            IList<TeamPlayer> TeamPlayerList = new List<TeamPlayer>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    TeamPlayerList = context.TeamPlayers
                        .Include(t => t.Person)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TeamPlayerList;
        }
        public IList<TeamPlayer> GetTeamPlayerList(int teamID)
        {
            IList<TeamPlayer> TeamPlayerList = new List<TeamPlayer>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    TeamPlayerList = context.TeamPlayers
                        .Include(t => t.Person)
                        .Where(t => t.TeamID == teamID)
                        .OrderBy(t => t.Person.FirstName)
                        .ThenBy(t => t.Person.LastName)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TeamPlayerList;
        }
        public TeamPlayer GetTeamPlayer(int teamID, int playerID)
        {
            TeamPlayer TeamPlayer = new TeamPlayer();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    TeamPlayer = context.TeamPlayers
                        .Where(c => c.TeamID == teamID && c.PlayerID == playerID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return TeamPlayer;
        }
        public TeamPlayer GetTeamPlayerByPlayerID(int playerID)
        {
            TeamPlayer teamPlayer = new TeamPlayer();
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    teamPlayer = context.TeamPlayers
                        .Where(c => c.PlayerID == playerID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamPlayer;
        }
    }
}
