using ClassLibrary.Database;
using ClassLibrary.Logic.CoachModelLogic;
using ClassLibrary.Logic.Team;
using ClassLibrary.Logic.TeamLogic;
using ClassLibrary.Models;
using PagedList;
using System.Web.Mvc;

namespace NetballGameSystem1.Controllers
{
    public class CoachController : Controller
    {
        private ICoachModelPageListLogic _coachModelPageListLogic;
        private ICoachModelSelectLogic _coachModelSelectLogic;
        private ICoachModelInsertLogic _insertCoachModelLogic;
        private ITeamSelectLogic _teamSelectLogic;
        private ITeamUpdateLogic _teamUpdateLogic;
        private ITeamParseLogic _teamParseLogic;

        public CoachController(ICoachModelPageListLogic coachModelPageListLogic,
            ICoachModelSelectLogic coachModelSelectLogic,
            ICoachModelInsertLogic insertCoachModelLogic,
            ITeamSelectLogic teamSelectLogic,
            ITeamUpdateLogic teamUpdateLogic,
            ITeamParseLogic teamParseLogic)
        {
            _coachModelPageListLogic = coachModelPageListLogic;
            _coachModelSelectLogic = coachModelSelectLogic;
            _insertCoachModelLogic = insertCoachModelLogic;
            _teamSelectLogic = teamSelectLogic;
            _teamUpdateLogic = teamUpdateLogic;
            _teamParseLogic = teamParseLogic;
        }
        // GET: Coach
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            IPagedList<CoachModel> coachModelPagedList;
            int pageNumber = (page ?? 1);

            coachModelPagedList = _coachModelPageListLogic.GetPagedList(pageNumber);
            return View(coachModelPagedList);
        }
        [HttpGet]
        public ActionResult Edit(int personID)
        {
            CoachModel coachModel = new CoachModel();
            coachModel = _coachModelSelectLogic.CoachModelSelect(personID);
            return View(coachModel);
        }
        [HttpPost]
        public ActionResult Edit(CoachModel coachModel)
        {
            IPagedList<CoachModel> coachModelPagedList;
            Team team = new Team();
            Team team1 = new Team();

            if (_coachModelSelectLogic.CoachModelSelect(coachModel.personID) == null)
            {
                _insertCoachModelLogic.InsertCoachModel(coachModel);
            }

            if (coachModel.teamID > 0)
            {
                team = _teamParseLogic.ParseTeam(coachModel);
                team1 = _teamSelectLogic.GetTeam(coachModel.teamID);

                if (team1 != null)
                {
                    team.TeamName = team1.TeamName;
                    _teamUpdateLogic.TeamUpdateTransaction(team);
                }
            }

            coachModelPagedList = _coachModelPageListLogic.GetPagedList(1, 9);
            return View("Index", coachModelPagedList);
        }
    }
}