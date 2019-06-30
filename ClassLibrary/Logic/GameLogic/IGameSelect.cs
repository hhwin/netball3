using System.Collections.Generic;

namespace ClassLibrary.Logic.Game
{
    public interface IGameSelect
    {
        Database.Game GetGame(int gameID);
        IList<Database.Game> GetGameList();
    }
}