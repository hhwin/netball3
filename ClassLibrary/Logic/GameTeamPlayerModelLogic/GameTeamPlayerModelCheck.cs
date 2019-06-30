using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public class GameTeamPlayerModelCheck : IGameTeamPlayerModelCheck
    {
        /// <summary>
        /// Returns true if at least one of the quarter indicators is true.
        /// </summary>
        /// <param name="gameTeamPlayerModel"></param>
        /// <returns></returns>
        public bool CheckQuarterInd(GameTeamPlayerModel gameTeamPlayerModel)
        {
            return (gameTeamPlayerModel.firstQuarterInd || gameTeamPlayerModel.secondQuarterInd || gameTeamPlayerModel.thirdQuarterInd || gameTeamPlayerModel.fourthQuarterInd);
        }
    }
}