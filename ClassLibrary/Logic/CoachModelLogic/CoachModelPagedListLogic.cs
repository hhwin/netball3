using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class CoachModelPagedListLogic : ICoachModelPageListLogic
    {
        private ICoachModelListLogic _coachModelListLogic;

        public CoachModelPagedListLogic(ICoachModelListLogic coachModelListLogic)
        {
            _coachModelListLogic = coachModelListLogic;
        }
        public IPagedList<CoachModel> GetPagedList(int? page, int pageSize = 10)
        {
            IList<CoachModel>coachModelList;
            coachModelList = _coachModelListLogic.GetCoachModelList();

            if (coachModelList != null && coachModelList.Count > 0)
            {
                int pageNumber = (page ?? 1);
                return coachModelList.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
    }
}
