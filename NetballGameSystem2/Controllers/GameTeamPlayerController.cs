using ClassLibrary.Database;
using ClassLibrary.Logic.GameTeamLogic;
using ClassLibrary.Logic.GameTeamModelLogic;
using ClassLibrary.Logic.GameTeamPlayerModelLogic;
using ClassLibrary.Models;
using PagedList;
using System.Web.Mvc;

namespace NetballGameSystem1.Controllers
{
    public class GameTeamPlayerController : Controller
    {
        private IGameTeamPlayerModelSelect _gameTeamPlayerModelSelect;
        private IGameTeamPlayerModelInsert _gameTeamPlayerModelInsert;
        private IGameTeamPlayerModelUpdate _gameTeamPlayerModelUpdate;
        private IGameTeamPlayerModelCheck _gameTeamPlayerModelCheck;
        private IGameTeamPlayerModelDelete _gameTeamPlayerModelDelete;
        private IGameTeamModelSelect _gameTeamModelSelect;
        private IGameTeamPlayerModelPagedList _gameTeamPlayerModelPagedList;
        private IGameTeamSelect _gameTeamSelect;

        public GameTeamPlayerController(
            IGameTeamPlayerModelSelect gameTeamPlayerModelSelect,
            IGameTeamPlayerModelInsert gameTeamPlayerModelInsert,
            IGameTeamPlayerModelUpdate gameTeamPlayerModelUpdate,
            IGameTeamPlayerModelCheck gameTeamPlayerModelCheck,
            IGameTeamPlayerModelDelete gameTeamPlayerModelDelete,
            IGameTeamModelSelect gameTeamModelSelect,
            IGameTeamPlayerModelPagedList gameTeamPlayerModelPagedList,
            IGameTeamSelect gameTeamSelect)
        {
            _gameTeamPlayerModelSelect = gameTeamPlayerModelSelect;
            _gameTeamPlayerModelInsert = gameTeamPlayerModelInsert;
            _gameTeamPlayerModelUpdate = gameTeamPlayerModelUpdate;
            _gameTeamPlayerModelCheck = gameTeamPlayerModelCheck;
            _gameTeamPlayerModelDelete = gameTeamPlayerModelDelete;
            _gameTeamModelSelect = gameTeamModelSelect;
            _gameTeamPlayerModelPagedList = gameTeamPlayerModelPagedList;
            _gameTeamSelect = gameTeamSelect;
        }
        private void PopulateViewBag(int gameTeamID)
        {
            GameTeamModel gameTeamModel;
            gameTeamModel = _gameTeamModelSelect.GetGameTeamModel(gameTeamID);
            ViewBag.teamName = gameTeamModel.teamName;
            ViewBag.courtName = gameTeamModel.courtName;
            ViewBag.matchNo = gameTeamModel.matchNo;
            ViewBag.venue = gameTeamModel.venue ?? "\t";
            ViewBag.datePlayed = gameTeamModel.datePlayed;
            ViewBag.primaryUmpire = gameTeamModel.primaryUmpire;
            ViewBag.secondaryUmpire = gameTeamModel.secondaryUmpire;
            ViewBag.reserveUmpire = gameTeamModel.reserveUmpire;
            ViewBag.gameID = gameTeamModel.gameID;
        }
        private void PopulateNullViewBag(int gameTeamID)
        {
            GameTeam gameTeam = new GameTeam();
            gameTeam = _gameTeamSelect.GetGameTeam(gameTeamID);

            if (gameTeam != null)
            {
                ViewBag.gameID = gameTeam.GameID;
            }
        }
        // GET: GameTeamPlayer
        public ActionResult Index(int gameTeamID, int? page)
        {
            IPagedList pagedList; 
            pagedList = _gameTeamPlayerModelPagedList.GetPagedList(gameTeamID, page);

            if (pagedList != null)
            {
                PopulateViewBag(gameTeamID);
                return View("Index", pagedList);
            }
            else
            {
                ViewBag.datePlayed = null;
                PopulateNullViewBag(gameTeamID);
                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult Create(int gameTeamID)
        {
            GameTeamPlayerModel gameTeamPlayerModel = new GameTeamPlayerModel();
            gameTeamPlayerModel = _gameTeamPlayerModelSelect.GetNewGameTeamPlayerModel(gameTeamID);
            return View(gameTeamPlayerModel);
        }
        [HttpPost]
        public ActionResult Create(GameTeamPlayerModel gameTeamPlayerModel)
        {
            IPagedList pagedList;
            ViewBag.Message = string.Empty;

            if (_gameTeamPlayerModelSelect.GetGameTeamPlayerModel(gameTeamPlayerModel.gameTeamID, gameTeamPlayerModel.playerID) == null)
            {
                if (_gameTeamPlayerModelCheck.CheckQuarterInd(gameTeamPlayerModel))
                {
                    _gameTeamPlayerModelInsert.GameTeamPlayerInsertLogic(gameTeamPlayerModel);
                    pagedList = _gameTeamPlayerModelPagedList.GetPagedList(gameTeamPlayerModel.gameTeamID, null);

                    if (pagedList != null)
                    {
                        return View("Index", pagedList);
                    }
                    else
                    {
                        ViewBag.Message = "Error in getting paged list for game team ID " + gameTeamPlayerModel.gameTeamID.ToString();
                    }
                }
                else
                {
                    ViewBag.Message = "At least one of the quarter check boxes must be checked.";
                }
            }
            else
            {
                ViewBag.Message = "Duplicate game team player encountered. Data has not been saved.";
            }
            gameTeamPlayerModel = _gameTeamPlayerModelSelect.GetNewGameTeamPlayerModel(gameTeamPlayerModel.gameTeamID);
            return View(gameTeamPlayerModel);
        }
        [HttpGet]
        public ActionResult Edit(int gamePlayerID,
            string controllerName,
            string viewName)
        {
            GameTeamPlayerModel gameTeamPlayerModel = new GameTeamPlayerModel();
            gameTeamPlayerModel = _gameTeamPlayerModelSelect.GetGameTeamPlayerModel(gamePlayerID);
            ViewBag.controllerName = controllerName;
            ViewBag.viewName = viewName;
            return View(gameTeamPlayerModel);
        }
        [HttpPost]
        public ActionResult Edit(GameTeamPlayerModel gameTeamPlayerModel)
        {
            GameTeamPlayerModel gameTeamPlayerModel1;
            gameTeamPlayerModel1 = _gameTeamPlayerModelSelect.GetGameTeamPlayerModel(gameTeamPlayerModel.gameTeamID, gameTeamPlayerModel.playerID);
            IPagedList pagedList;

            if (gameTeamPlayerModel.gamePlayerID == gameTeamPlayerModel1.gamePlayerID)
            {
                _gameTeamPlayerModelUpdate.GameTeamPlayerUpdateLogic(gameTeamPlayerModel);
                pagedList = _gameTeamPlayerModelPagedList.GetPagedList(gameTeamPlayerModel.gameTeamID, null);

                if (pagedList != null)
                {
                    PopulateViewBag(gameTeamPlayerModel.gameTeamID);
                    return View("Index", pagedList);
                }
            }
            return View(gameTeamPlayerModel);
        }
        [HttpGet]
        public ActionResult Delete(int gamePlayerID)
        {
            GameTeamPlayerModel gameTeamPlayerModel = new GameTeamPlayerModel();
            gameTeamPlayerModel = _gameTeamPlayerModelSelect.GetGameTeamPlayerModel(gamePlayerID);
            return View(gameTeamPlayerModel);
        }
        [HttpPost]
        public ActionResult Delete(GameTeamPlayerModel gameTeamPlayerModel)
        {
            _gameTeamPlayerModelDelete.GameTeamPlayerDeleteLogic(gameTeamPlayerModel);

            return View("Index", _gameTeamPlayerModelPagedList.GetPagedList(gameTeamPlayerModel.gameTeamID, null));
        }
    }
}