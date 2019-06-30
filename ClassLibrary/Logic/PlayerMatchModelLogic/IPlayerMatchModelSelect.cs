using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerMatchModelLogic
{
    public interface IPlayerMatchModelSelect
    {
        PlayerMatchModel GetPlayerMatchModel(int personID, int? pageNumber, int? pageSize);
    }
}