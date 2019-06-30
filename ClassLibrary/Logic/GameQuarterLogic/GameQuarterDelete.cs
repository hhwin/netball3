
namespace ClassLibrary.Logic.GameQuarter
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class GameQuarterDelete : IGameQuarterDelete
    {
        /// <summary>
        /// Deletes a given GameQuarter object. 
        /// </summary>
        /// <param name="GameQuarter"></param> 

        public void GameQuarterRemove(GameQuarter gamequarter)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gamequarter).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
