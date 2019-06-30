
namespace ClassLibrary.Logic.QuarterType
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    /// <summary>
    /// Get quartertype details including person details.
    /// </summary>
    public class QuarterTypeSelect : IQuarterTypeSelect
    {
        public QuarterType GetQuarterType(int quartertypeID)
        {
            QuarterType quartertype = new QuarterType();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    quartertype = context.QuarterTypes
                        .Include(c => c.GameQuarters)
                        .Where(c => c.QuarterTypeID == quartertypeID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return quartertype;
        }

        public IList<QuarterType> GetQuarterTypeList()
        {
            IList<QuarterType> quartertypeList = new List<QuarterType>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    quartertypeList = context.QuarterTypes
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return quartertypeList;
        }
    }
}
