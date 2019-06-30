using System;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameIndexModelLogic
{
    public interface IGameIndexModelInitialiseLogic
    {
        GameIndexModel InitialiseGameIndexModel(int? teamID, int? divisionID, DateTime? datePlayed, int? page);
    }
}