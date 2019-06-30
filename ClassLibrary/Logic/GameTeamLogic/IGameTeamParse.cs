using System.Collections.Generic;
using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamLogic
{
    public interface IGameTeamParse
    {
        IList<GameTeam> ParseGameTeam(GameModel gameModel);
    }
}