using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamModelLogic
{
    public interface IGameTeamModelSelect
    {
        GameTeamModel GetGameTeamModel(int gameTeamID);
    }
}