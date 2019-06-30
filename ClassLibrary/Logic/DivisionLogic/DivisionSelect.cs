
namespace ClassLibrary.Logic.Division
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;

    /// <summary>
    /// Get division details including person details.
    /// </summary>
    public class DivisionSelect : IDivisionSelect
    {
        public Division GetDivision(int divisionID)
        {
            Division division = new Division();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    division = context.Divisions
                        .Where(c => c.DivisionID == divisionID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return division;
        }

        public IList<Division> GetDivisionList()
        {
            IList<Division> divisionList = new List<Division>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    divisionList = context.Divisions
                        .AsNoTracking()
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return divisionList;
        }
    }
}
