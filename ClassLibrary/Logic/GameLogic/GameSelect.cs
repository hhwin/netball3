
namespace ClassLibrary.Logic.Game
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;

    /// <summary>
    /// Get game details including person details.
    /// </summary>
    public class GameSelect : IGameSelect
    {
        public Game GetGame(int gameID)
        {
            Game game = new Game();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    game = context.Games
                        .Where(c => c.GameID == gameID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return game;
        }

        public IList<Game> GetGameList()
        {
            IList<Game> gameList = new List<Game>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameList = context.Games
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameList;
        }
    }
}
