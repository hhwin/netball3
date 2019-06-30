using System;
using System.Collections.Generic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public interface IGameModelListParameterLogic
    {
        IList<GameModel> GetGameModelListParameter(int teamID, int divisionID, DateTime? datePlayed);
    }
}