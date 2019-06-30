using ClassLibrary.Database;
using System;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary.Logic.GamePlayerLogic
{
    public class GamePlayerDelete : IGamePlayerDelete
    {
        /// <summary>          
        /// Deletes a given GamePlayer object.           
        /// </summary>          
        /// <param name="GamePlayer"></param>              
        public void GamePlayerRemove(GamePlayer gameplayer)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gameplayer).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GamePlayerRemove(int gamePlayerID)
        {
            GamePlayer gamePlayer = new GamePlayer();
            using (NetballEntities context = new NetballEntities())
            {
                gamePlayer = context.GamePlayers
                    .Where(g => g.GamePlayerID == gamePlayerID)
                    .FirstOrDefault();

                if (gamePlayer != null)
                {
                    GamePlayerRemove(gamePlayer);
                }
            }
        }
    }
}