using System.Collections.Generic;

namespace ClassLibrary.Logic.GameQuarter
{
    public interface IGameQuarterSelect
    {
        Database.GameQuarter GetGameQuarter(int gamequarterID);
        IList<Database.GameQuarter> GetGameQuarterList();
    }
}