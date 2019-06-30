using ClassLibrary.Logic.Court;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.CourtLogic
{
    public class CourtSelectList : CourtSelect, ICourtSelectList
    {
        public List<SelectListItem> GetCourtSelectList(int courtID = 0)
        {
            List<SelectListItem> courtItem = new List<SelectListItem>();
            IList<Database.Court> courtList = GetCourtList();

            courtItem.Add(new SelectListItem
            {
                Text = "-- Select court --",
                Value = "0",
                Selected = (courtID == 0)
            });

            foreach (Database.Court court in courtList)
                courtItem.Add(new SelectListItem
                {
                    Text = court.Court1,
                    Value = court.CourtID.ToString(),
                    Selected = (court.CourtID == courtID)
                });

            return courtItem;
        }

        public static List<SelectListItem> GetCourtSelectListStatic(int courtID)
        {
            CourtSelectList courtSelectList = new CourtSelectList();
            return courtSelectList.GetCourtSelectList(courtID);
        }
    }
}