
namespace ClassLibrary.Logic.QuarterType
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class QuarterTypeUpdate : IQuarterTypeUpdate
    {
        public int? QuarterTypeUpdateTransaction(QuarterType quartertype)
        {
            int? quartertypeID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(quartertype).State = EntityState.Modified;
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
