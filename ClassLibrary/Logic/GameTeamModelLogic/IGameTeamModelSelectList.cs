using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamModelLogic
{
    public interface IGameTeamModelSelectList
    {
        IList<GameTeamModel> GetGameTeamModelSelectList(int teamID);
    }
}