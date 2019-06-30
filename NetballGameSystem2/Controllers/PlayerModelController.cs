using ClassLibrary.Logic.PlayerModelLogic;
using ClassLibrary.Models;
using PagedList;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class PlayerModelController : Controller
    {
        private IPlayerModelListLogic _playerModelList;
        private IPlayerModelPageList _playerModelPageList;

        public PlayerModelController(IPlayerModelListLogic playerModelList,
            IPlayerModelPageList playerModelPageList)
        {
            _playerModelList = playerModelList;
            _playerModelPageList = playerModelPageList;
        }
        // GET: PlayerModel
        public ActionResult Index(string controllerName,
            string viewName,
            int? page,
            int teamID = 1)
        {
            int pageNumber = page ?? 1;
            IPagedList<PlayerModel> pagedList;
            pagedList = _playerModelPageList.GetPageList(teamID, pageNumber);

            ViewBag.controllerName = controllerName;
            ViewBag.viewName = viewName;

            if (pagedList != null)
            {
                return View(pagedList);
            }
            else
            {
                return null;
            }        
        }
    }
}