using System.Collections.Generic;

namespace ClassLibrary.Logic.Division
{
    public interface IDivisionSelect
    {
        Database.Division GetDivision(int divisionID);
        IList<Database.Division> GetDivisionList();
    }
}