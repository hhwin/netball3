using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ClassLibrary.Database;
using ClassLibrary.Models;
using ClassLibrary.Logic.AwardLogic;
using ClassLibrary.Logic.AwardLogic.AwardModelLogic;
using ClassLibrary.Logic.AwardModelLogic;

namespace NetballGameSystem2.Controllers
{
    public class AwardModelsController : Controller
    {
        private NetballEntities db = new NetballEntities();
        private IAwardModelSelectList _awardModelSelectList;
        private IAwardModelInsertLogic _awardModelInsertLogic;
        private IAwardModelUpdateLogic _awardModelUpdateLogic;
        private IAwardModelSelect _awardModelSelect;
        private IAwardModelDeleteLogic _awardModelDeleteLogic;
        private IAwardModelPagedList _awardModelPagedList;

        public AwardModelsController(IAwardModelSelectList awardModelSelectList,
                                     IAwardModelInsertLogic awardModelInsertLogic,
                                     IAwardModelUpdateLogic awardModelUpdateLogic,
                                     IAwardModelSelect awardModelSelect,
                                     IAwardModelDeleteLogic awardModelDelete,
                                     IAwardModelPagedList awardModelPagedList)
        {
            _awardModelSelectList = awardModelSelectList;
            _awardModelInsertLogic = awardModelInsertLogic;
            _awardModelUpdateLogic = awardModelUpdateLogic;
            _awardModelSelect = awardModelSelect;
            _awardModelDeleteLogic = awardModelDelete;
            _awardModelPagedList = awardModelPagedList;
        }

        // GET: AwardModels
        public async Task<ActionResult> Index()
        {
            IList<AwardModel> awardModelList;
            awardModelList = await _awardModelSelectList.GetAwardModelList();
            return View(awardModelList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            AwardModel awardModel = new AwardModel();
            return View(awardModel);
        }

        [HttpPost]
        public ActionResult Create(AwardModel awardModel)
        {             
            _awardModelInsertLogic.InsertAwardModel(awardModel);
            return View(awardModel);
        }       

        public ActionResult Edit(int awardID)
        {
            AwardModel awardModel = new AwardModel();
            //awardModel = _gameTeamPlayerModelSelect.GetGameTeamPlayerModel(awardID);

            return View(awardModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AwardModel awardModel)
        {
            _awardModelUpdateLogic.UpdateAwardModel(awardModel);
            return View(awardModel);
        } 
        
        public async Task<ActionResult> Delete(int awardID)
        {
            AwardModel awardModel = new AwardModel();
            awardModel = await _awardModelSelect.GetAwardModel(awardID); 
            return View(awardModel);
        }

        [HttpPost]
        public ActionResult Delete(AwardModel awardModel)
        {
            _awardModelDeleteLogic.DeleteAwardModel(awardModel);

            return View("Index", _awardModelPagedList.GetPagedList(awardModel.AwardID, null));
        }

        //// POST: AwardModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    AwardModel awardModel = db.AwardModels.Find(id);
        //    db.AwardModels.Remove(awardModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


    }
}
