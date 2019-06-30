using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public interface IGameModelListLogic
    {
        IList<GameModel> GetGameModelList();
    }
}