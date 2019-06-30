
namespace ClassLibrary.Logic.Court
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;

    /// <summary>
    /// Get court details 
    /// </summary>
    public class CourtSelect : ICourtSelect
    {
        public Court GetCourt(int courtID)
        {
            Court court = new Court();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    court = context.Courts
                        .Where(c => c.CourtID == courtID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return court;
        }

        public IList<Court> GetCourtList()
        {
            IList<Court> courtList = new List<Court>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    courtList = context.Courts
                        .AsNoTracking()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return courtList;
        }
    }
}
