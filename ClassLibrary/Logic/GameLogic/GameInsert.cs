
namespace ClassLibrary.Logic.Game
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class GameInsert : IGameInsert
    {
        /// <summary>
        /// Insert a Game object in Game table returning GameID if successful.
        /// GameID = null if failed.
        /// </summary>
        /// <param name="Game"></param>
        /// <returns></returns>
        public int? GameAdd(Game game)
        {
            int? gameID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(game).State = EntityState.Added;
                    context.SaveChanges();
                    gameID = game.GameID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameID;
        }
    }
}
