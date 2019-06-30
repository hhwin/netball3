using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class CoachModelCheckLogic : ICoachModelCheckLogic
    {
        /// <summary>
        /// Returns true if the coachPersonID matches the team's coach. Logic assumes one coach per team.
        /// </summary>
        IGetCoachModelLogic _getCoachModelLogic;

        public CoachModelCheckLogic(IGetCoachModelLogic getCoachModelLogic)
        {
            _getCoachModelLogic = getCoachModelLogic;
        }

        public bool CheckCoachModel(int coachPersonID, int teamID)
        {
            CoachModel coachModel = new CoachModel();
            coachModel = _getCoachModelLogic.GetActiveCoachModel(teamID);

            if (coachModel == null)
            {
                return false;
            }
            else
            {
                return (coachModel.personID == coachPersonID);
            }
        }
    }
}