using ClassLibrary.Models;
using PagedList;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public interface ICoachModelPageListLogic
    {
        IPagedList<CoachModel> GetPagedList(int? page, int pageSize = 10);
    }
}