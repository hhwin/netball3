using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerIndexModelLogic
{
    public interface IPlayerIndexModelSelectLogic
    {
        PlayerIndexModel GetPlayerIndexModel(int? teamID, int? page);
        PlayerIndexModel GetPlayerIndexModel(string playerName, int? page);
    }
}