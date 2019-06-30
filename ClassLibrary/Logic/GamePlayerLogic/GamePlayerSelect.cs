using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Database;
using System;

namespace ClassLibrary.Logic.GamePlayerLogic
{
    /// <summary>
    /// Get gameplayer details including person details.
    /// </summary>
    public class GamePlayerSelect : IGamePlayerSelect
    {
        public GamePlayer GetGamePlayer(int gameplayerID)
        {
            GamePlayer gameplayer = new GamePlayer();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameplayer = context.GamePlayers
                        .Include(g => g.Person)
                        .Include(g => g.GameTeam.Game)
                        .Include(g => g.GameTeam.Team)
                        .Where(c => c.GamePlayerID == gameplayerID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameplayer;
        }

        public IList<GamePlayer> GetGamePlayerList()
        {
            IList<GamePlayer> gameplayerList = new List<GamePlayer>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameplayerList = context.GamePlayers
                        .Include(g => g.Person)
                        .Include(g => g.GameTeam.Game)
                        .Include(g => g.GameTeam.Team)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameplayerList;
        }

        public IList<GamePlayer>GetGamePlayerList(int playerID,
            int teamID)
        {
            IList<GamePlayer> gamePlayerList = new List<GamePlayer>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gamePlayerList = context.GamePlayers
                        .Include(g => g.Person)
                        .Include(g => g.GameTeam)
                        .Include(g => g.GameTeam.Game)
                        .Include(g => g.GameTeam.Team)
                        .Where(g => g.PlayerID == playerID && g.GameTeam.TeamID == teamID)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gamePlayerList;
        }
    }
}
