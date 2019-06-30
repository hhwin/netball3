using ClassLibrary.Models;
using System;

namespace ClassLibrary.Logic.GameModelLogic
{
    public interface IGameModelSelectLogic
    {
        GameModel GetGameModel(int gameID);
        GameModel GetGameModel(int courtID,
            DateTime datePlayed,
            TimeSpan startTime);
    }
}