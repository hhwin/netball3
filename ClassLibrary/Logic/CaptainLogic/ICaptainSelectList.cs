using System.Collections.Generic;
using System.Web.Mvc;

namespace ClassLibrary.Logic.CaptainLogic
{
    public interface ICaptainSelectList
    {
        List<SelectListItem> GetCaptainSelectList(int teamID, string text = "-- Select team player --");
    }
}