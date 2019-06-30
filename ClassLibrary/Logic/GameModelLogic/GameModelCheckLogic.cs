using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameModelLogic
{
    public class GameModelCheckLogic : IGameModelCheckLogic
    {
        private IGameModelCheckTeams _gameModelCheckTeams;
        private IGameModelCheckDuplicateLogic _gameModelCheckDuplicateLogic;

        public GameModelCheckLogic(IGameModelCheckTeams gameModelCheckTeams,
                    IGameModelCheckDuplicateLogic gameModelCheckDuplicateLogic)
        {
            _gameModelCheckTeams = gameModelCheckTeams;
            _gameModelCheckDuplicateLogic = gameModelCheckDuplicateLogic;
        }
        public bool GameModelCheck(GameModel gameModel,
            ref string validationMessage)
        {
            validationMessage = null;

            if (gameModel.courtID == 0)
            {
                validationMessage = "Court must be selected";
            }
            else if ((gameModel.primaryUmpireID??0) != 0
                && (gameModel.secondaryUmpireID??0) != 0
                && gameModel.primaryUmpireID == gameModel.secondaryUmpireID)
            {
                validationMessage = "Primary umpire cannot be same person secondary umpire.";
            }
            else if ((gameModel.primaryUmpireID??0) != 0
                && (gameModel.reserveUmpireID??0) != 0
                && gameModel.primaryUmpireID == gameModel.reserveUmpireID)
            {
                validationMessage = "Primary umpire cannot be same person reserve umpire.";
            }
            else if ((gameModel.secondaryUmpireID??0) != 0
                && (gameModel.reserveUmpireID??0) != 0
                && gameModel.secondaryUmpireID == gameModel.reserveUmpireID)
            {
                validationMessage = "Secondary umpire cannot be same person reserve umpire.";
            }
            else if (!_gameModelCheckTeams.CheckTeams(gameModel))
            {
                validationMessage = "Team cannot play against themselves.";
            }            
            else if (gameModel.team1ID == 0)
            {
                validationMessage = "Please select a (home) team";
            }
            else if (gameModel.team2ID == 0)
            {
                validationMessage = "Please select a (outside) team";
            }
            else if (gameModel.gameID == 0 && !_gameModelCheckDuplicateLogic.GameModelCheckDuplicate(gameModel.courtID, gameModel.datePlayed, gameModel.startTime))
            {
                validationMessage = "Game has been duplicated.";
            }
            return string.IsNullOrEmpty(validationMessage);
        }
    }
}