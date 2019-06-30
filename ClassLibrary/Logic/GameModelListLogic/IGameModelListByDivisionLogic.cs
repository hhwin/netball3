using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public interface IGameModelListByDivisionLogic
    {
        IList<GameModel> GetGameModelListByDivision(int divisionID);
    }
}