using ClassLibrary.Logic.Division;
using ClassLibrary.Logic.DivisionModelLogic;
using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;

namespace ClassLibrary.Logic.DivisionIndexModelLogic
{
    public class DivisionIndexModelSelectListLogic : IDivisionIndexModelSelectListLogic
    {
        private IDivisionModelListLogic _divisionModelListLogic;
        private IDivisionSelect _divisionSelect;

        public DivisionIndexModelSelectListLogic(IDivisionModelListLogic divisionModelListLogic,
            IDivisionSelect divisionSelect)
        {
            _divisionModelListLogic = divisionModelListLogic;
            _divisionSelect = divisionSelect;
        }
        public DivisionIndexModel GetDivisionIndexModel(int? divisionID, int? page)
        {
            DivisionIndexModel divisionIndexModel = new DivisionIndexModel();
            Database.Division division = new Database.Division();

            if (divisionID != null)
            {
                division = _divisionSelect.GetDivision((int)divisionID);

                if (division != null)
                {
                    divisionIndexModel.Division = division.Division1;
                    divisionIndexModel.DivisionID = division.DivisionID;
                }
            }
           
            divisionIndexModel.divisionModelPagedList = GetPagedList(divisionID, page);
            return divisionIndexModel;
        }
        private IPagedList<DivisionModel> GetPagedList(int? divisionID, int? page)
        {
            const int pageSize = 10;
            int pageNumber = page ?? 1;
            IList<DivisionModel> divisionModelList = null;
            IPagedList<DivisionModel> divisionModelPagedList = null;

            if (divisionID == null)
            {
                divisionModelList = _divisionModelListLogic.GetDivisionModelList();
            }
            else if (divisionID != null)
            {
                divisionModelList = _divisionModelListLogic.GetDivisionModelList((int)divisionID);
            }
            if (divisionModelList != null)
            {
                divisionModelPagedList = divisionModelList.ToPagedList(pageNumber, pageSize);
            }
            return divisionModelPagedList;
        }
    }
}
