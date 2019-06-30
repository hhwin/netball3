using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameModelLogic
{
    public interface IGameModelCheckLogic
    {
        bool GameModelCheck(GameModel gameModel, ref string validationMessage);
    }
}