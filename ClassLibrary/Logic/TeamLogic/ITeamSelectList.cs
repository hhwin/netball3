using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.Team
{
    public interface ITeamSelectList
    {
        List<SelectListItem> GetTeamSelectList(int teamID = 0);
    }
}