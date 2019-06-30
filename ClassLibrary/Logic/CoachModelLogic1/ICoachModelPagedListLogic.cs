using System.Collections.Generic;
using ClassLibrary.Models;
using PagedList;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public interface ICoachModelPagedListLogic1
    {
        IPagedList<CoachModel> GetCoachModelPagedList(IList<CoachModel> coachModelList, int? page, int pageSize = 10);
    }
}