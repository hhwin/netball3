using ClassLibrary.Database;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public class UpdatePlayerModelLogic : IUpdatePlayerModelLogic
    {
        /// <summary>
        /// Update player model object.
        /// </summary>
        private IPlayerModelParse _playerModelParse;
        private IPersonUpdate _personUpdate;

        public UpdatePlayerModelLogic(IPlayerModelParse playerModelParse,
            IPersonUpdate personUpdate)
        {
            _playerModelParse = playerModelParse;
            _personUpdate = personUpdate;
        }
        public void UpdatePlayerModel(PlayerModel playerModel)
        {
            Person person = new Person();
            person = _playerModelParse.ParsePerson(playerModel);
            _personUpdate.PersonUpdateTransaction(person);
        }
    }
}