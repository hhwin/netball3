using ClassLibrary.Database;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public class PlayerModelInsertLogic : IPlayerModelInsertLogic
    {
        /// <summary>
        ///  Insert player model into person object.
        /// </summary>
        private PlayerModelParse _playerModelParse;
        private PersonInsert _personInsert;

        public PlayerModelInsertLogic(PlayerModelParse playerModelParse,
            PersonInsert personInsert)
        {
            _playerModelParse = playerModelParse;
            _personInsert = personInsert;
        }

        public void InsertPlayerModel(ref PlayerModel playerModel)
        {
            Person person = new Person();
            person = _playerModelParse.ParsePerson(playerModel);
            _personInsert.PersonAdd(person);
            playerModel.personID = person.PersonID;
        }
    }
}