using ClassLibrary.Logic.GameTeamModelLogic;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class GameTeamController : Controller
    {
        private GameTeamModelSelectList _gameTeamModelSelectList;

        public GameTeamController(GameTeamModelSelectList gameTeamModelSelectList)
        {
            _gameTeamModelSelectList = gameTeamModelSelectList;
        }
        // GET: GameTeam
        public ActionResult Index()
        {
            IList<GameTeamModel> gameTeamModelList = new List<GameTeamModel>();
            gameTeamModelList = _gameTeamModelSelectList.GetGameTeamModelSelectList(1);
            return View(gameTeamModelList);
        }
    }
}