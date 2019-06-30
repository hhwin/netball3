using ClassLibrary.Models;

namespace ClassLibrary.Logic.Game
{
    public class GameParse : IGameParse
    {
        public Database.Game ParseGame(GameModel gameModel)
        {
            Database.Game game = new Database.Game();

            game.CourtID = gameModel.courtID;
            game.DatePlayed = gameModel.datePlayed;
            game.DivisionID = gameModel.divisionID == 0?null:gameModel.divisionID;
            game.ExtraTimeEnd = gameModel.extraTimeEnd;
            game.FullTime = gameModel.fullTime;
            game.GameID = gameModel.gameID;
            game.MatchNo = gameModel.matchNo;
            //game.MatchWonByTeamID = gameModel.m
            game.PrimaryUmpireID = gameModel.primaryUmpireID==0?null:gameModel.primaryUmpireID;
            game.ReserveUmpireID = gameModel.reserveUmpireID==0?null:gameModel.reserveUmpireID;
            game.Scorer1ID = gameModel.scorer1ID==0?null:gameModel.scorer1ID;
            game.Scorer2ID = gameModel.scorer2ID==0?null:gameModel.scorer2ID;
            game.SecondaryUmpireID = gameModel.secondaryUmpireID==0?null:gameModel.secondaryUmpireID;
            game.StartTime = gameModel.startTime;
            game.TimeKeeper1ID = gameModel.timeKeeper1ID==0?null:gameModel.timeKeeper1ID;
            game.TimeKeeper2ID = gameModel.timeKeeper2ID==0?null:gameModel.timeKeeper2ID;
            game.TournamentID = gameModel.tournamentID;
            game.Venue = gameModel.venue;

            return game;
        }
    }
}