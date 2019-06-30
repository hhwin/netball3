using ClassLibrary.Database;
using ClassLibrary.Logic.CaptainLogic;
using ClassLibrary.Logic.GameTeamLogic;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameModelLogic
{
    public class GameModelDetailLogic : IGameModelDetailLogic
    {
        private IGameTeamSelect _gameTeamSelect;
        private IPersonSelect _personSelect;
        private ICaptainSelect _captainSelect;

        public GameModelDetailLogic(IGameTeamSelect gameTeamSelect,
            IPersonSelect personSelect,
            ICaptainSelect captainSelect)
        {
            _gameTeamSelect = gameTeamSelect;
            _personSelect = personSelect;
            _captainSelect = captainSelect;
        }

        public GameModel GetGameModelDetail(GameModel gameModel)
        {
            IList<GameTeam> gameTeamList = null;
            int row = 0;
            int? team1ID = null;
            int? team2ID = null;
            int? finalScore1 = null;
            int? finalScore2 = null;
            string teamName1 = null;
            string teamName2 = null;
            int? coach1ID = null;
            int? coach2ID = null;
            int gameTeam1ID = 0;
            int gameTeam2ID = 0;
            PlayerModel playerModel;

            try
            {
                gameTeamList = _gameTeamSelect.GetGameTeamList(gameModel.gameID);

                if (gameModel.primaryUmpireID != null)
                {
                    Person person = _personSelect.GetPerson(gameModel.primaryUmpireID ?? 0);
                    gameModel.primaryUmpire = person.FirstName + " " + person.LastName;
                }
                if (gameModel.secondaryUmpireID != null)
                {
                    Person person = _personSelect.GetPerson(gameModel.secondaryUmpireID ?? 0);
                    gameModel.secondaryUmpire = person.FirstName + " " + person.LastName;
                }
                if (gameModel.reserveUmpire != null)
                {
                    Person person = _personSelect.GetPerson(gameModel.reserveUmpireID ?? 0);
                    gameModel.reserveUmpire = person.FirstName + " " + person.LastName;
                }
                if (gameModel.scorer1ID != null)
                {
                    Person person = _personSelect.GetPerson(gameModel.scorer1ID ?? 0);
                    gameModel.scorer1 = person.FirstName + " " + person.LastName;
                }
                if (gameModel.scorer2ID != null)
                {
                    Person person = _personSelect.GetPerson(gameModel.scorer2ID ?? 0);
                    gameModel.scorer2 = person.FirstName + " " + person.LastName;
                }
                if (gameModel.timeKeeper1ID != null)
                {
                    Person person = _personSelect.GetPerson(gameModel.timeKeeper1ID ?? 0);
                    gameModel.scorer1 = person.FirstName + " " + person.LastName;
                }
                if (gameModel.timeKeeper2ID != null)
                {
                    Person person = _personSelect.GetPerson(gameModel.timeKeeper2ID ?? 0);
                    gameModel.scorer1 = person.FirstName + " " + person.LastName;
                }

                if (gameTeamList != null)
                {
                    foreach (GameTeam gameTeam in gameTeamList)
                    {
                        ++row;

                        if (row == 1)
                        {
                            team1ID = gameTeam.TeamID;
                            teamName1 = gameTeam.Team.TeamName;
                            finalScore1 = gameTeam.FinalScore;
                            coach1ID = gameTeam.CoachID;
                            gameTeam1ID = gameTeam.GameTeamID;
                        }
                        else
                        {
                            team2ID = gameTeam.TeamID;
                            teamName2 = gameTeam.Team.TeamName;
                            finalScore2 = gameTeam.FinalScore;
                            coach2ID = gameTeam.CoachID;
                            gameTeam2ID = gameTeam.GameTeamID;
                        }
                        gameModel.team1ID = team1ID ?? 0;
                        gameModel.team1Name = teamName1;
                        gameModel.team1ScoreFinal = finalScore1 ?? 0;
                        gameModel.coach1ID = coach1ID;
                        gameModel.gameTeam1ID = gameTeam1ID;
                        gameModel.team2ID = team2ID ?? 0;
                        gameModel.team2Name = teamName2;
                        gameModel.team2ScoreFinal = finalScore2 ?? 0;
                        gameModel.coach2ID = coach2ID;
                        gameModel.gameTeam2ID = gameTeam2ID;
                    }

                    playerModel =_captainSelect.GetCaptain(gameModel.team1ID);
                    if (playerModel != null)
                    {
                        gameModel.captain1ID = playerModel.personID;
                        gameModel.captain1 = playerModel.playerName;
                    }

                    playerModel = _captainSelect.GetCaptain(gameModel.team2ID);
                    if (playerModel != null)
                    {
                        gameModel.captain2ID = playerModel.personID;
                        gameModel.captain2 = playerModel.playerName;
                    }

                    if (gameModel.coach1ID != null)
                    {
                        Person person = _personSelect.GetPerson(gameModel.coach1ID ?? 0);
                        gameModel.coach1 = person.FirstName + " " + person.LastName;
                    }
                    if (gameModel.coach2ID != null)
                    {
                        Person person = _personSelect.GetPerson(gameModel.coach2ID ?? 0);
                        gameModel.coach2 = person.FirstName + " " + person.LastName;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return gameModel;
        }
    }
}