using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public interface IPlayerModelListLogic
    {
        IList<PlayerModel> BasePlayerModelList();
        IList<PlayerModel> GetPlayerModelList(int teamID);
        IList<PlayerModel> GetPlayerModelList(string playerName);
        IList<PlayerModel> GetPlayerModelList(int teamID, string playerName);
    }
}