using ClassLibrary.Database;
using System;
using System.Data.Entity;

namespace ClassLibrary.Logic.GamePlayerLogic
{
    public class GamePlayerInsert : IGamePlayerInsert
    {
        /// <summary>
        /// Insert a GamePlayer object in GamePlayer table returning GamePlayerID if successful.
        /// GamePlayerID = null if failed.
        /// </summary>
        /// <param name="GamePlayer"></param>
        /// <returns></returns>
        public int? GamePlayerAdd(GamePlayer gameplayer)
        {
            int? gameplayerID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gameplayer).State = EntityState.Added;
                    context.SaveChanges();
                    gameplayerID = gameplayer.GamePlayerID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameplayerID;
        }
    }
}
