using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.DivisionLogic
{
    public interface IDivisionSelectList
    {
        List<SelectListItem> GetDivisionSelectList(int? divisionID);
    }
}