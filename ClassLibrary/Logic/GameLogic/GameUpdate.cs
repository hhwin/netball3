
namespace ClassLibrary.Logic.Game
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class GameUpdate : IGameUpdate
    {
        public int? GameUpdateTransaction(Game game)
        {
            int? gameID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(game).State = EntityState.Modified;
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
