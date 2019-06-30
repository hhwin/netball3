using ClassLibrary.Models;
using PagedList;

namespace ClassLibrary.Logic.DivisionModelLogic
{
    public interface IDivisionModelPagedListLogic
    {
        IPagedList<DivisionModel> GetPagedList(int? divisionID, int? page, int pageSize = 10);
    }
}