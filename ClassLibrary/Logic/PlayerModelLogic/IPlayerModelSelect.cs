using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public interface IPlayerModelSelect
    {
        PlayerModel GetPlayerModel(int personID, int teamID);
        PlayerModel GetPlayerModel(string firstName, string lastName);
        IList<PlayerModel> GetPlayerModelList(int personID);
    }
}