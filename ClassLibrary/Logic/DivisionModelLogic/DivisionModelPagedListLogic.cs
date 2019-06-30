using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;

namespace ClassLibrary.Logic.DivisionModelLogic
{
    public class DivisionModelPagedListLogic : IDivisionModelPagedListLogic
    {
        private IDivisionModelListLogic _divisionModelListLogic;

        public DivisionModelPagedListLogic(IDivisionModelListLogic divisionModelListLogic)
        {
            _divisionModelListLogic = divisionModelListLogic;
        }
        public IPagedList<DivisionModel>GetPagedList(int? divisionID,
            int? page, 
            int pageSize=10)
        {
            IList<DivisionModel> divisionList = new List<DivisionModel>();
            int pageNumber = page ?? 1;

            if (divisionID == null)
            {
                divisionList = _divisionModelListLogic.GetDivisionModelList();
            }
            else
            {
                divisionList = _divisionModelListLogic.GetDivisionModelList((int)divisionID);
            }

            if (divisionList != null && divisionList.Count > 0)
            {
                return divisionList.ToPagedList(pageNumber, pageSize);
            }
            else
            {
                return null;
            }
        }
    }
}
