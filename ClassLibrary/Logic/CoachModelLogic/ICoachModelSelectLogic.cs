using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public interface ICoachModelSelectLogic
    {
        CoachModel CoachModelSelect(int personID);
    }
}