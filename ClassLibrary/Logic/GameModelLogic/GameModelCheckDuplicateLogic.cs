using System;

namespace ClassLibrary.Logic.GameModelLogic
{
    public class GameModelCheckDuplicateLogic : IGameModelCheckDuplicateLogic
    {
        /// <summary>
        /// Check if game model contains a duplicate row for the court ID, date played and start time and returns true if no duplicate found.
        /// </summary>
        IGameModelSelectLogic _gameModelSelectLogic;

        public GameModelCheckDuplicateLogic(IGameModelSelectLogic gameModelSelectLogic)
        {
            _gameModelSelectLogic = gameModelSelectLogic;
        }
        public bool GameModelCheckDuplicate(int courtID, 
            DateTime datePlayed,
            TimeSpan startTime)
        {
            return (_gameModelSelectLogic.GetGameModel(courtID, datePlayed, startTime) == null);
        }
    }
}