using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public class PlayerModelCheckLogic : IPlayerModelCheckLogic
    {
        /// <summary>
        /// Check if the player model has been duplicated based on first name and last name.
        /// </summary>
        private IPlayerModelSelect _playerModelSelect;

        public PlayerModelCheckLogic(IPlayerModelSelect playerModelSelect)
        {
            _playerModelSelect = playerModelSelect;
        }
        public bool CheckPlayerModel(PlayerModel playerModel)
        {
            PlayerModel checkPlayer;
            checkPlayer = _playerModelSelect.GetPlayerModel(playerModel.firstName, playerModel.lastName);
            return (checkPlayer == null || checkPlayer.personID == playerModel.personID);
        }
    }
}