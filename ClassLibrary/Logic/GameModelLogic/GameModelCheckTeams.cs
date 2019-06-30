using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameModelLogic
{
    public class GameModelCheckTeams : IGameModelCheckTeams
    {
        /// <summary>
        /// Returns true if team1ID != team2ID in game Model.
        /// Prevents team playing against themselves.
        /// </summary>
        /// <param name="gameModel"></param>
        /// <returns></returns>
        public bool CheckTeams(GameModel gameModel)
        {
            return (gameModel.team1ID != gameModel.team2ID);
        }
    }
}