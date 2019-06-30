using ClassLibrary.Logic.DivisionIndexModelLogic;
using ClassLibrary.Models;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class DivisionController : Controller
    {
        private IDivisionIndexModelSelectListLogic _divisionIndexModelSelectListLogic;

        public DivisionController(IDivisionIndexModelSelectListLogic divisionIndexModelSelectListLogic)
        {
            _divisionIndexModelSelectListLogic = divisionIndexModelSelectListLogic;
        }
        // GET: Division
        public ActionResult Index(int? divisionID, int? page)
        {
            DivisionIndexModel divisionIndexModel;
            int pageNumber = page ?? 1;
            divisionID = divisionID == 0 ? null : divisionID;
            divisionIndexModel = _divisionIndexModelSelectListLogic.GetDivisionIndexModel(divisionID, pageNumber);
            return View(divisionIndexModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            DivisionModel divisionModel = new DivisionModel();
            return View(divisionModel);
        }
        [HttpPost]
        public ActionResult Create(DivisionModel divisionModel)
        {
            return View(divisionModel);
        }
    }
}