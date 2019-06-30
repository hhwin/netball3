using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public interface IGameModelListByTeamLogic
    {
        IList<GameModel> GetGameModelListByTeam(int teamID);
    }
}