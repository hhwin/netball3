using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public interface IGetCoachModelListByNameLogic
    {
        IList<CoachModel> GetCoachModelListByFirstName(string firstName);
        IList<CoachModel> GetCoachModelListByLastName(string lastName);
        IList<CoachModel> GetCoachModelListByName(string lastName, string firstName);
    }
}