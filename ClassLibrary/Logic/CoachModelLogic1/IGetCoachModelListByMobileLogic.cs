using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public interface IGetCoachModelListByMobileLogic
    {
        IList<CoachModel> GetCoachModelListByMobile(string mobile);
    }
}