using ClassLibrary.Logic.TeamPlayerModelLogic;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class TeamPlayerModelController : Controller
    {
        //ITeamPlayerModelPagedList _teamPlayerModelPagedList;
        ITeamPlayerModelSelectList _teamPlayerModelSelectList;

        public TeamPlayerModelController()
        { }

        public TeamPlayerModelController(
            ITeamPlayerModelSelectList teamPlayerModelSelectList)
        {
            //_teamPlayerModelPagedList = teamPlayerModelPagedList;
            _teamPlayerModelSelectList = teamPlayerModelSelectList;
        }
        // GET: TeamPlayerModel
        public ActionResult Index(int teamID, int? pageNumber)
        {
            IList<TeamPlayerModel> teamPlayerModelList = _teamPlayerModelSelectList.GetTeamPlayerModelList(teamID);
            return View(teamPlayerModelList);
        }
    }
}