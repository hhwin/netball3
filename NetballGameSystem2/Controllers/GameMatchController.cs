using ClassLibrary.Logic.GameIndexModelLogic;
using ClassLibrary.Models;
using System;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class GameMatchController : Controller
    {
        private IGameIndexModelInitialiseLogic _gameIndexModelInitialiseLogic;

        public GameMatchController(IGameIndexModelInitialiseLogic gameIndexModelInitialiseLogic)
        {
            _gameIndexModelInitialiseLogic = gameIndexModelInitialiseLogic;
        }
        // GET: GameMatch
        public ActionResult Index(int? page, int? teamID, DateTime? datePlayed,
            string teamName)
        {
            GameIndexModel gameIndexModel = new GameIndexModel();
            int currTeamID = teamID??0;
            int pageNumber = page ?? 1;

            ViewBag.teamID = currTeamID;
            ViewBag.datePlayed = datePlayed;
            ViewBag.teamName = teamName;
            gameIndexModel.datePlayed = datePlayed;
            gameIndexModel.teamID = currTeamID;
            gameIndexModel = _gameIndexModelInitialiseLogic.InitialiseGameIndexModel(currTeamID, 1, datePlayed, pageNumber);
            return View(gameIndexModel);
        }
    }
}