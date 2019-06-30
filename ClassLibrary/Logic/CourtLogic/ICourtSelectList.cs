using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.CourtLogic
{
    public interface ICourtSelectList
    {
        List<SelectListItem> GetCourtSelectList(int courtID = 0);
    }
}