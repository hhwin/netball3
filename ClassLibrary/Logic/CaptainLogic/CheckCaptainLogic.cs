using ClassLibrary.Models;

namespace ClassLibrary.Logic.CaptainLogic
{
    public class CheckCaptainLogic : ICheckCaptainLogic
    {
        /// <summary>
        ///  Returns true if person is captain of this team (teamID).
        /// </summary>
        private ICaptainSelect _captainSelect;

        public CheckCaptainLogic(ICaptainSelect captainSelect)
        {
            _captainSelect = captainSelect;
        }

        public bool CheckCaptain(int teamID, int personID)
        {
            PlayerModel captain;
            captain = _captainSelect.GetCaptain(teamID);

            if (captain == null)
            {
                return true;
            }
            else if (captain.personID == personID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}