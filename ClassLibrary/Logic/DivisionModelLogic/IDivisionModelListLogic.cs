using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.DivisionModelLogic
{
    public interface IDivisionModelListLogic
    {
        IList<DivisionModel> GetDivisionModelList();
        IList<DivisionModel> GetDivisionModelList(int divisionID);
    }
}