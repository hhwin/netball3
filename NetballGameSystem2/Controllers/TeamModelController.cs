using ClassLibrary.Logic.TeamModelLogic;
using ClassLibrary.Models;
using PagedList;
using System.Web.Mvc;

namespace NetballGameSystem1.Controllers
{
    public class TeamModelController : Controller
    {
        private ITeamModelListLogic _teamModelListLogic;
        private ITeamModelSelectLogic _teamModelSelectLogic;

        public TeamModelController(ITeamModelListLogic teamModelListLogic,
            ITeamModelSelectLogic teamModelSelectLogic)
        {
            _teamModelListLogic = teamModelListLogic;
            _teamModelSelectLogic = teamModelSelectLogic;
        }
        public ActionResult Index(int? page, string CurrentFilter, int? teamID)
        {
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            ViewBag.teamID = teamID;
            TeamIndexModel teamIndexModel = new TeamIndexModel();
            teamIndexModel.TeamPagedList = (_teamModelListLogic.GetTeamModelList(teamID > 0 ? teamID : 0)).ToPagedList(pageNumber, pageSize);
            return View(teamIndexModel);
        }
        public ActionResult Edit(int teamID)
        {
            TeamModel teamModel;
            teamModel = _teamModelSelectLogic.GetTeamModel(teamID);
            ViewBag.teamID = teamID;
            return View(teamModel);
        }
    }
}