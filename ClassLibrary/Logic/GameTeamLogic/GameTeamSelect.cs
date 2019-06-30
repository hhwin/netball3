namespace ClassLibrary.Logic.GameTeamLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    /// <summary>
    /// Get gameteam details including person details.
    /// </summary>
    public class GameTeamSelect : IGameTeamSelect
    {
        public GameTeam GetGameTeam(int gameTeamID)
        {
            GameTeam gameteam = new GameTeam();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameteam = context.GameTeams
                        .Where(c => c.GameTeamID == gameTeamID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameteam;
        }

        public IList<GameTeam> GetGameTeamList()
        {
            IList<GameTeam> gameteamList = new List<GameTeam>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameteamList = context.GameTeams
                        .OrderBy(g => g.GameTeamID)
                        .ThenBy(g => g.GameTeamID)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameteamList;
        }
        public IList<GameTeam> GetGameTeamList(int gameID)
        {
            IList<GameTeam> gameTeamList = new List<GameTeam>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    gameTeamList = context.GameTeams
                        .Include(g => g.Team)
                        .Where(g => g.GameID == gameID)
                        .OrderBy(g => g.TeamID)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameTeamList;
        }
        public IList<GameTeam>GetGameTeamList(int gameID, 
            int playerID)
        {
            IList<GameTeam> gameTeamList = new List<GameTeam>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    gameTeamList = context.GamePlayers
                        .Include(g => g.GameTeam)
                        .Include(g => g.GameTeam.Team)
                        .Where(g => g.PlayerID == playerID)
                        .Where(g => g.GameTeam.GameID == gameID)
                        .Select(g => new GameTeam
                        {
                            GameTeamID = g.GameTeamID,
                            GameID = g.GameTeam.GameID,
                            TeamID = g.GameTeam.TeamID,
                            CaptainID = g.GameTeam.CaptainID,
                            CoachID = g.GameTeam.CoachID,
                            PrimaryCarerID = g.GameTeam.PrimaryCarerID,
                            FinalScore = g.GameTeam.FinalScore
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameTeamList;
        }
        public IList<GameTeam>GetGameTeamByTeamID(int teamID)
        {
            IList<GameTeam> gameTeamList = new List<GameTeam>();
            IList<GameTeam> gameTeamList1 = new List<GameTeam>();
            IList<GameTeam> list = new List<GameTeam>();

            using (NetballEntities context = new NetballEntities())
            {
                gameTeamList = context.GameTeams
                    .Where(g => g.TeamID == teamID)
                    .ToList();

                foreach(GameTeam gameTeam in gameTeamList)
                {
                    list = context.GameTeams
                        .Where(g => g.GameID == gameTeam.GameID)
                        .ToList();
                
                    gameTeamList1.Add(list[0]);
                    gameTeamList1.Add(list[1]);
                }
            }
            return gameTeamList1;
        }
    }
}
