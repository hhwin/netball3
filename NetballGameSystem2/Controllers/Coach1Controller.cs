using ClassLibrary.Logic.CoachModelLogic;
using ClassLibrary.Logic.CoachModelLogic1;
using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class Coach1Controller : Controller
    {
        private ICoachModelSelectListLogic1 _coachModelSelectListLogic1;
        private ICoachModelPagedListLogic1 _coachModelPagedListLogic;
        private IGetCoachModelListByEmailLogic _getCoachModelListByEmailListLogic;
        private IGetCoachModelListByMobileLogic _getCoachModelListByMobileLogic;
        private IGetCoachModelListByNameLogic _getCoachModelListByNameLogic;
        private IGetCoachModelListByTeamLogic _getCoachModelListByTeamLogic;
        private IGetCoachModelLogic1 _getCoachModelLogic1;

        public Coach1Controller(ICoachModelSelectListLogic1 coachModelSelectListLogic1,
            ICoachModelListLogic coachModelListLogic,
            ICoachModelPagedListLogic1 coachModelPagedListLogic,
            IGetCoachModelListByEmailLogic getCoachModelListByEmailListLogic,
            IGetCoachModelListByMobileLogic getCoachModelListByMobileLogic,
            IGetCoachModelListByNameLogic getCoachModelListByNameLogic,
            IGetCoachModelListByTeamLogic getCoachModelListByTeamLogic,
            IGetCoachModelLogic1 getCoachModelLogic1)
        {
            _coachModelSelectListLogic1 = coachModelSelectListLogic1;
            _coachModelPagedListLogic = coachModelPagedListLogic;
            _getCoachModelListByEmailListLogic = getCoachModelListByEmailListLogic;
            _getCoachModelListByMobileLogic = getCoachModelListByMobileLogic;
            _getCoachModelListByNameLogic = getCoachModelListByNameLogic;
            _getCoachModelListByTeamLogic = getCoachModelListByTeamLogic;
            _getCoachModelLogic1 = getCoachModelLogic1;
        }
        // GET: Coach1
        public ActionResult Index(int? teamID,
            string firstName,
            string lastName,
            int? page)
        {
            int pageNumber = page ?? 1;
            CoachIndexModel coachIndexModel = new CoachIndexModel();
            IList<CoachModel> coachModelList = new List<CoachModel>();
            IPagedList<CoachModel> coachModelPagedList;
            teamID = teamID ?? 0;

            if (teamID == 0 && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                coachModelList = _coachModelSelectListLogic1.GetCoachModelSelectList();
            }
            else if (teamID != 0)
            {
                coachModelList = _getCoachModelListByTeamLogic.GetCoachModelByTeamID((int)teamID);
            }
            else if (!string.IsNullOrEmpty(firstName))
            {
                coachModelList = _getCoachModelListByNameLogic.GetCoachModelListByFirstName(firstName);
            }

            coachModelPagedList = _coachModelPagedListLogic.GetCoachModelPagedList(coachModelList, pageNumber);
            coachIndexModel.coachPagedList = coachModelPagedList;
            return View(coachIndexModel);
        }
        public ActionResult Details(int coachID = 1)
        {
            CoachModel coachModel;
            coachModel = _getCoachModelLogic1.GetCoach(coachID);
            return View(coachModel);
        }
    }
}