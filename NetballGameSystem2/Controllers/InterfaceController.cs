using ClassLibrary.Logic.InterfaceDemoLogic;
using ClassLibrary.Models;
using System.Web.Mvc;

namespace NetballGameSystem2.Controllers
{
    public class InterfaceController : Controller
    {
        private IPeople _people;

        public InterfaceController(IPeople people)
        {
            _people = people;
        }
        public ActionResult Details()
        {
            PeopleModel peopleModel = new PeopleModel();
            peopleModel.MyID = _people.MyID();
            peopleModel.MyName = _people.MyName();
            peopleModel.MyOccuptaion = _people.MyOccuptaion();

            return View(peopleModel);
        }
    }
}