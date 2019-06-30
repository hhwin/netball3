using ClassLibrary.Database;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GamePlayerLogic
{
    public interface IGamePlayerSelect
    {
        GamePlayer GetGamePlayer(int gameplayerID);
        IList<GamePlayer> GetGamePlayerList();
        IList<GamePlayer> GetGamePlayerList(int playerID, int teamID);
    }
}