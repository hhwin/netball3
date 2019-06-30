using ClassLibrary.Database;
using ClassLibrary.Models;
using System;

namespace ClassLibrary.Logic.GamePlayerLogic
{
    public class GamePlayerParse : IGamePlayerParse
    {
        public GamePlayer GamePlayerParseLogic(GameTeamPlayerModel gameTeamPlayerModel)
        {
            GamePlayer gamePlayer = new GamePlayer();

            try
            {
                gamePlayer.GamePlayerID = gameTeamPlayerModel.gamePlayerID;
                gamePlayer.PlayerID = gameTeamPlayerModel.playerID;
                gamePlayer.GameTeamID = gameTeamPlayerModel.gameTeamID;
                gamePlayer.FirstQuarterInd = gameTeamPlayerModel.firstQuarterInd;
                gamePlayer.SecondQuarterInd = gameTeamPlayerModel.secondQuarterInd;
                gamePlayer.ThirdQuarterInd = gameTeamPlayerModel.thirdQuarterInd;
                gamePlayer.FourthQuarterInd = gameTeamPlayerModel.fourthQuarterInd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return gamePlayer;
        }
    }
}