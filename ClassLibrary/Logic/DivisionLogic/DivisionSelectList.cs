using ClassLibrary.Logic.Division;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.DivisionLogic
{
    public class DivisionSelectList : DivisionSelect, IDivisionSelectList
    {
        public List<SelectListItem> GetDivisionSelectList(int? divisionID)
        {
            List<SelectListItem> divisionItem = new List<SelectListItem>();
            IList<Database.Division> divisionList = GetDivisionList();
            divisionID = divisionID ?? 0;

            divisionItem.Add(new SelectListItem
            {
                Text = "-- Select division --",
                Value = "0",
                Selected = (divisionID == 0)
            });

            foreach (Database.Division division in divisionList)
                divisionItem.Add(new SelectListItem
                {
                    Text = division.Division1,
                    Value = division.DivisionID.ToString(),
                    Selected = (division.DivisionID == divisionID)
                });

            return divisionItem;
        }

        public static List<SelectListItem> GetDivisionSelectListStatic(int? divisionID)
        {
            DivisionSelectList divisionSelectList = new DivisionSelectList();
            return divisionSelectList.GetDivisionSelectList(divisionID);
        }
    }
}
