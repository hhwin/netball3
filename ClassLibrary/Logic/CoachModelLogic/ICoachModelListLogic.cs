using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public interface ICoachModelListLogic
    {
        IList<CoachModel> GetCoachModelList();
    }
}