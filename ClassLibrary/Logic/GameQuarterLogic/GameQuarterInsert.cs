
namespace ClassLibrary.Logic.GameQuarter
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class GameQuarterInsert : IGameQuarterInsert
    {
        /// <summary>
        /// Insert a GameQuarter object in GameQuarter table returning GameQuarterID if successful.
        /// GameQuarterID = null if failed.
        /// </summary>
        /// <param name="GameQuarter"></param>
        /// <returns></returns>
        public int? GameQuarterAdd(GameQuarter gamequarter)
        {
            int? gamequarterID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gamequarter).State = EntityState.Added;
                    context.SaveChanges();
                    gamequarterID = gamequarter.GameQuarterID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gamequarterID;
        }
    }
}
