using System.Collections.Generic;

namespace ClassLibrary.Logic.Court
{
    public interface ICourtSelect
    {
        Database.Court GetCourt(int courtID);
        IList<Database.Court> GetCourtList();
    }
}