namespace ClassLibrary.Logic.Game
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class GameDelete : IGameDelete
    {
        /// <summary>          /// Deletes a given Game object.           
        /// </summary>          
        /// <param name="Game"></param>              
        public void GameRemove(Game game)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(game).State = EntityState.Deleted; context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}