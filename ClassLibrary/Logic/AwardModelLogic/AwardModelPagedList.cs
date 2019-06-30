using ClassLibrary.Logic.AwardLogic.AwardModelLogic;
using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public class AwardModelPagedList : IAwardModelPagedList
    {
        private IAwardModelSelectList _awardModelSelectList;

        public AwardModelPagedList(IAwardModelSelectList awardModelSelectList)
        {
            _awardModelSelectList = awardModelSelectList;
        }

        public async  Task<IPagedList<AwardModel>> GetPagedList(int awardID,int? page,int pageSize = 6)
        {
            IList<AwardModel> awardModelList;
            int pageNumber = page ?? 1;

            awardModelList = await _awardModelSelectList.GetAwardModelList(awardID);

            if (awardModelList != null && awardModelList.Count > 0)
            {
                return awardModelList.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
    }
}
