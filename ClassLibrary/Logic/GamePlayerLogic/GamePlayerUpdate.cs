using System;
using ClassLibrary.Database;
using System.Data.Entity;

namespace ClassLibrary.Logic.GamePlayerLogic
{

    public class GamePlayerUpdate : IGamePlayerUpdate
    {
        public int? GamePlayerUpdateTransaction(GamePlayer gameplayer)
        {
            int? gameplayerID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gameplayer).State = EntityState.Modified;
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
