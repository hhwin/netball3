using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public interface IPlayerModelSaveLogic
    {
        void PlayerModelSave(PlayerModel playerModel, ref string message);
    }
}