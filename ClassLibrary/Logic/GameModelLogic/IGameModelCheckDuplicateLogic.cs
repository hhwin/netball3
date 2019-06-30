using System;

namespace ClassLibrary.Logic.GameModelLogic
{
    public interface IGameModelCheckDuplicateLogic
    {
        bool GameModelCheckDuplicate(int courtID, DateTime datePlayed, TimeSpan startTime);
    }
}