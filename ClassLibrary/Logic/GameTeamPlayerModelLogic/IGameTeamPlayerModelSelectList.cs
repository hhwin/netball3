using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public interface IGameTeamPlayerModelSelectList
    {
        IList<GameTeamPlayerModel> GetGameTeamPlayerModelList(int gameTeamID);
    }
}