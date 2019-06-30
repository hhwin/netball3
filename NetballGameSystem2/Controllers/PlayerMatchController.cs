using ClassLibrary.Database;
using ClassLibrary.Logic.PlayerMatchModelLogic;
using ClassLibrary.Logic.TeamPlayerLogic;
using ClassLibrary.Models;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class PlayerMatchController : Controller
    {
        private IPlayerMatchModelSelect _playerMatchModelSelect;
        private ITeamPlayersSelect _teamPlayersSelect;

        public PlayerMatchController(IPlayerMatchModelSelect playerMatchModelSelect,
            ITeamPlayersSelect teamPlayersSelect)
        {
            _playerMatchModelSelect = playerMatchModelSelect;
            _teamPlayersSelect = teamPlayersSelect;
        }
        // GET: PlayerMatch
        public ActionResult Index(int playerID, 
            string controllerName,
            string viewName,
            int? page)
        {
            PlayerMatchModel playerMatchModel;
            int pageNumber = page ?? 1;
            TeamPlayer teamPlayer;
            ViewBag.playerID = playerID;
            ViewBag.controllerName = controllerName;
            ViewBag.viewName = viewName;

            if (controllerName == "Player" && viewName == "Index")
            {
                teamPlayer = _teamPlayersSelect.GetTeamPlayerByPlayerID(playerID);
                if (teamPlayer != null)
                {
                    ViewBag.TeamID = teamPlayer.TeamID;
                }
            }
            playerMatchModel = _playerMatchModelSelect.GetPlayerMatchModel(playerID, pageNumber, null);
            
            return View(playerMatchModel);
        }
    }
}