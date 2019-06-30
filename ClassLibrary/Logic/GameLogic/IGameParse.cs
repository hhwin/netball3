using ClassLibrary.Models;

namespace ClassLibrary.Logic.Game
{
    public interface IGameParse
    {
        Database.Game ParseGame(GameModel gameModel);
    }
}