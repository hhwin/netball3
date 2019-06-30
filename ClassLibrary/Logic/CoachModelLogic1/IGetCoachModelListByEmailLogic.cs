using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public interface IGetCoachModelListByEmailLogic
    {
        IList<CoachModel> GetCoachModelListByEmail(string email);
    }
}