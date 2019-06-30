using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameMatchModelLogic
{
    public interface IGameMatchModelSelectLogic
    {
        IList<GameMatchModel> GetGameMatchModelList(int playerID);
    }
}