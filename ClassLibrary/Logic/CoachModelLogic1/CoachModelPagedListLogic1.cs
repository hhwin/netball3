using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public class CoachModelPagedListLogic1 : ICoachModelPagedListLogic1
    {
        public IPagedList<CoachModel> GetCoachModelPagedList(IList<CoachModel>coachModelList, 
            int? page, 
            int pageSize = 10)
        {
            int pageNumber = page ?? 1;

            if (coachModelList != null && coachModelList.Count > 0)
            {
                return coachModelList.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
    }
}
