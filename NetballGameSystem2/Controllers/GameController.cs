using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClassLibrary.Logic.CaptainLogic;
using ClassLibrary.Logic.GameIndexModelLogic;
using ClassLibrary.Logic.GameModelListLogic;
using ClassLibrary.Logic.GameModelLogic;
using ClassLibrary.Logic.TeamModelLogic;
using ClassLibrary.Models;
using System.Globalization;

namespace NetballGameSystem1.Controllers
{
    public class GameController : Controller
    {
        private IGameModelListLogic _gameModelListLogic;
        private IGameModelSelectLogic _gameModelSelectLogic;
        private ITeamModelListLogic _teamModelListLogic;
        private IGameModelInsertLogic _gameModelInsertLogic;
        private IGameModelUpdateLogic _gameModelUpdateLogic;
        private ICaptainSelectList _captainSelectList;
        private IGameModelCheckLogic _gameModelCheckLogic;
        private IGameIndexModelParameterLogic _gameIndexModelParameterLogic;
        private IGameIndexModelInitialiseLogic _initialiseGameIndexModelLogic;

        public GameController(IGameModelListLogic gameModelListLogic,
            IGameModelSelectLogic gameModelSelectLogic,
            ITeamModelListLogic teamModelListLogic,
            IGameModelInsertLogic gameModelInsertLogic,
            IGameModelUpdateLogic gameModelUpdateLogic,
            ICaptainSelectList captainSelectList,
            IGameModelCheckLogic gameModelCheckLogic,
            IGameIndexModelParameterLogic gameIndexModelParameterLogic,
            IGameIndexModelInitialiseLogic initialiseGameIndexModelLogic)
        {
            _gameModelListLogic = gameModelListLogic;
            _gameModelSelectLogic = gameModelSelectLogic;
            _teamModelListLogic = teamModelListLogic;
            _captainSelectList = captainSelectList;
            _gameModelInsertLogic = gameModelInsertLogic;
            _gameModelUpdateLogic = gameModelUpdateLogic;
            _gameModelCheckLogic = gameModelCheckLogic;
            _gameIndexModelParameterLogic = gameIndexModelParameterLogic;
            _initialiseGameIndexModelLogic = initialiseGameIndexModelLogic;
        }
        public ActionResult Index(string searchString, int? teamID, int? divisionID, DateTime? datePlayed, int? page)
        {
            GameIndexModel gameIndexModel = new GameIndexModel();
            ViewBag.CurrentFilter = searchString;
            ViewBag.teamID = teamID ?? 0;
            ViewBag.divisionID = divisionID ?? 0;
            ViewBag.datePlayed = datePlayed;
            gameIndexModel = _initialiseGameIndexModelLogic.InitialiseGameIndexModel(teamID, divisionID, datePlayed, page);
            return View(gameIndexModel);
        }
        [HttpGet]
        public ActionResult Edit(int gameID,
            string controllerName,
            string viewName,
            int? playerID = null)
        {
            GameModel gameModel = new GameModel();
            gameModel = _gameModelSelectLogic.GetGameModel(gameID);
            ViewBag.controllerName = controllerName;
            ViewBag.viewName = viewName;
            ViewBag.playerID = playerID;
            return View(gameModel);
        }
        [HttpPost]
        public ActionResult Edit(GameModel gameModel, 
            string controllerName,
            string viewName,
            int? pIayerID = null)
        {
            string validationMessage = null;
            GameIndexModel gameIndexModel = new GameIndexModel();
            ViewBag.playerID = pIayerID;
            ViewBag.controllerName = controllerName;
            ViewBag.viewName = viewName;

            if (_gameModelCheckLogic.GameModelCheck(gameModel, ref validationMessage))
            {
                _gameModelUpdateLogic.GameModelUpdate(gameModel);
                gameIndexModel = _initialiseGameIndexModelLogic.InitialiseGameIndexModel(null, null, null, null);
                return View("Index", gameIndexModel);
            }
            else
            {
                ViewBag.ValidationMessage = validationMessage;
                return View(gameModel);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            GameModel gameModel = new GameModel();
            gameModel.datePlayed = DateTime.Now;
            gameModel.startTime = TimeSpan.ParseExact(DateTime.Now.ToString(@"hh\.mm"), @"hh\.mm", CultureInfo.InvariantCulture);
            gameModel.fullTime = TimeSpan.ParseExact(DateTime.Now.AddHours(1).ToString(@"hh\.mm"), @"hh\.mm", CultureInfo.InvariantCulture);
            return View(gameModel);
        }
        [HttpPost]
        public ActionResult Create(GameModel gameModel)
        {
            string validationMessage = null;

            if (_gameModelCheckLogic.GameModelCheck(gameModel, ref validationMessage))
            {
                GameIndexModel gameIndexModel = new GameIndexModel();
                _gameModelInsertLogic.GameModelInsert(gameModel);
                gameIndexModel = _initialiseGameIndexModelLogic.InitialiseGameIndexModel(null, null, null, null);
                return View("Index", gameIndexModel);
            }
            else
            {
                ViewBag.ValidationMessage = validationMessage;
                return View(gameModel);
            }
        }
        [HttpGet]
        public ActionResult GetCaptainPlayers(int teamID,
            int personID = 0)
        {
            IEnumerable<SelectListItem> captainTeamPlayers = _captainSelectList.GetCaptainSelectList(teamID);
            return Json(captainTeamPlayers, JsonRequestBehavior.AllowGet);
        }
    }
}