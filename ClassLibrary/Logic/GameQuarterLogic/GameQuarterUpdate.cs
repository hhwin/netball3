
namespace ClassLibrary.Logic.GameQuarter
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class GameQuarterUpdate : IGameQuarterUpdate
    {
        public int? GameQuarterUpdateTransaction(GameQuarter gamequarter)
        {
            int? gamequarterID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gamequarter).State = EntityState.Modified;
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
