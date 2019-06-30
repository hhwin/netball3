namespace ClassLibrary.Logic.GameQuarter
{
    using System.Collections.Generic;
    using System.Linq;
    using ClassLibrary.Database;
    using System;

    /// <summary>
    /// Get gamequarter details including person details.
    /// </summary>
    public class GameQuarterSelect : IGameQuarterSelect
    {
        public GameQuarter GetGameQuarter(int gamequarterID)
        {
            GameQuarter gamequarter = new GameQuarter();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gamequarter = context.GameQuarters
                        .Where(c => c.GameQuarterID == gamequarterID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gamequarter;
        }

        public IList<GameQuarter> GetGameQuarterList()
        {
            IList<GameQuarter> gamequarterList = new List<GameQuarter>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gamequarterList = context.GameQuarters
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gamequarterList;
        }
    }
}
