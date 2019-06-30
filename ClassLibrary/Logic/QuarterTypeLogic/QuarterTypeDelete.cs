
namespace ClassLibrary.Logic.QuarterType
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class QuarterTypeDelete : IQuarterTypeDelete
    {
        /// <summary>
        /// Deletes a given QuarterType object. 
        /// </summary>
        /// <param name="QuarterType"></param> 

        public void QuarterTypeRemove(QuarterType quartertype)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(quartertype).State = EntityState.Deleted;
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
