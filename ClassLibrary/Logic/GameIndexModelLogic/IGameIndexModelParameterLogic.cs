using ClassLibrary.Models;
using System;

namespace ClassLibrary.Logic.GameIndexModelLogic
{
    public interface IGameIndexModelParameterLogic
    {
        GameIndexModel GetGameIndexModelParameter(int? teamID, int? divisionID, int? page, DateTime? datePlayed);
    }
}