using ClassLibrary.Logic.PlayerIndexModelLogic;
using ClassLibrary.Logic.PlayerModelLogic;
using ClassLibrary.Models;
using System.Web.Mvc;

namespace NetballGameSystem1.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerModelListLogic _playerModelList;
        private IPlayerModelSaveLogic _playerModelSaveLogic;
        private IPlayerModelSelect _playerModelSelect;
        private IPlayerModelDeleteLogic _playerModelDeleteLogic;
        private IPlayerIndexModelSelectLogic _playerIndexModelSelectLogic;

        public PlayerController() { }

        public PlayerController(IPlayerModelSaveLogic playerModelSaveLogic,
            IPlayerModelSelect playerModelSelect,
            IPlayerModelListLogic playerModelList,
            IPlayerModelDeleteLogic playerModelDeleteLogic,
            IPlayerIndexModelSelectLogic playerIndexModelSelectLogic)
        {
            _playerModelSaveLogic = playerModelSaveLogic;
            _playerModelList = playerModelList;
            _playerModelSelect = playerModelSelect;
            _playerModelDeleteLogic = playerModelDeleteLogic;
            _playerIndexModelSelectLogic = playerIndexModelSelectLogic;
        }
        public ActionResult Index(string searchString, int? teamID, int? playerID, int? page)
        {
            ViewBag.teamID = teamID;
            ViewBag.playerID = playerID;
            ViewBag.CurrentFilter = searchString;

            PlayerIndexModel playerIndexModel = new PlayerIndexModel();
            if (teamID != null && teamID > 0)
            {
                playerIndexModel = _playerIndexModelSelectLogic.GetPlayerIndexModel(teamID, page);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                playerIndexModel = _playerIndexModelSelectLogic.GetPlayerIndexModel(searchString, page);
            }
            return View(playerIndexModel);
        }
        // EDIT: Player
        [HttpGet]
        public ActionResult Edit(int playerID,
            int teamID,
            string controllerName,
            string viewName)
        {
            PlayerModel playerModel = new PlayerModel();
            playerModel = _playerModelSelect.GetPlayerModel(playerID, teamID);
            ViewBag.controllerName = controllerName;
            ViewBag.viewName = viewName;
            ViewBag.playerID = playerID;
            ViewBag.teamID = teamID;
            return View(playerModel);
        }
        [HttpPost]
        public ActionResult Edit(PlayerModel playerModel,
            int playerID,
            int teamID)
        {
            string message = string.Empty;
            _playerModelSaveLogic.PlayerModelSave(playerModel, ref message);
            ViewBag.playerID = playerID;
            ViewBag.teamID = teamID;

            if (!string.IsNullOrEmpty(message))
            {
                TempData["statusMessage"] = message;
            }
            return View(playerModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            PlayerModel playerModel = new PlayerModel();
            return View(playerModel);
        }
        [HttpPost]
        public ActionResult Create(PlayerModel playerModel)
        {
            string message = string.Empty;
            _playerModelSaveLogic.PlayerModelSave(playerModel, ref message);

            if (!string.IsNullOrEmpty(message))
            {
                TempData["statusMessage"] = message;
            }
            return View(playerModel);
        }

        [HttpGet]
        public ActionResult Delete(int playerID,
            int teamID)
        {
            PlayerModel playerModel = new PlayerModel();
            playerModel = _playerModelSelect.GetPlayerModel(playerID, teamID);
            return View(playerModel);
        }
        [HttpPost]
        public ActionResult Delete(int playerID,
            int teamID,
            PlayerModel playerModel)
        {
            string message = string.Empty;
            PlayerIndexModel playerIndexModel = new PlayerIndexModel();
            //IList<PlayerModel> playerModelList = new List<PlayerModel>();
            _playerModelDeleteLogic.PlayerModelDelete(playerID, teamID, ref message);

            if (string.IsNullOrEmpty(message))
            {
                return View("Index", playerIndexModel);
            }
            else
            {
                playerModel = _playerModelSelect.GetPlayerModel(playerID, teamID);
                return View(playerModel);
            }
        }
    }
}