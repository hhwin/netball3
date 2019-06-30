using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameTeamLogic
{
    public class GameTeamParse : IGameTeamParse
    {
        public IList<GameTeam> ParseGameTeam(GameModel gameModel)
        {
            IList<GameTeam> gameTeamList = new List<GameTeam>();
            GameTeam gameTeam;

            gameTeam = new GameTeam();
            gameTeam.CaptainID = gameModel.captain1ID==0?null:gameModel.captain1ID;
            gameTeam.CoachID = gameModel.coach1ID==0?null:gameModel.coach1ID;
            gameTeam.GameID = gameModel.gameID;
            gameTeam.FinalScore = gameModel.team1ScoreFinal;
            gameTeam.GameTeamID = gameModel.gameTeam1ID;
            gameTeam.TeamID = gameModel.team1ID;
            gameTeamList.Add(gameTeam);

            gameTeam = new GameTeam();
            gameTeam.CaptainID = gameModel.captain2ID==0?null:gameModel.captain2ID;
            gameTeam.CoachID = gameModel.coach2ID==0?null:gameModel.coach2ID;
            gameTeam.GameID = gameModel.gameID;
            gameTeam.FinalScore = gameModel.team2ScoreFinal;
            gameTeam.GameTeamID = gameModel.gameTeam2ID;
            gameTeam.TeamID = gameModel.team2ID;
            gameTeamList.Add(gameTeam);

            return gameTeamList;
        }
    }
}