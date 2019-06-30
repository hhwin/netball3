using System.Collections.Generic;

namespace ClassLibrary.Logic.QuarterType
{
    public interface IQuarterTypeSelect
    {
        Database.QuarterType GetQuarterType(int quartertypeID);
        IList<Database.QuarterType> GetQuarterTypeList();
    }
}