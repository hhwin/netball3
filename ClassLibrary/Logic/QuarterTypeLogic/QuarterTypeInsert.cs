
namespace ClassLibrary.Logic.QuarterType
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class QuarterTypeInsert : IQuarterTypeInsert
    {
        /// <summary>
        /// Insert a QuarterType object in QuarterType table returning QuarterTypeID if successful.
        /// QuarterTypeID = null if failed.
        /// </summary>
        /// <param name="QuarterType"></param>
        /// <returns></returns>
        public int? QuarterTypeAdd(QuarterType quartertype)
        {
            int? quartertypeID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(quartertype).State = EntityState.Added;
                    context.SaveChanges();
                    quartertypeID = quartertype.QuarterTypeID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return quartertypeID;
        }
    }
}
