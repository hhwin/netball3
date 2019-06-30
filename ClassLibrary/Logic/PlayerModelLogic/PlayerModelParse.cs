using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    using ClassLibrary.Database;

    public class PlayerModelParse : IPlayerModelParse
    {
        public Person ParsePerson(PlayerModel playerModel)
        {
            Person person = new Person();
            person.PersonID = playerModel.personID;
            person.FirstName = playerModel.firstName;
            person.MiddleName = playerModel.middleName;
            person.LastName = playerModel.lastName;
            person.Mobile = playerModel.mobile;
            person.Email = playerModel.email;
            person.EmergencyContact = playerModel.emergencyContact;
            person.EmergencyContactNo = playerModel.emergencyContactNo;
            return person;
        }

        public PlayerModel ParsePlayerModel(Person person)
        {
            PlayerModel playerModel = new PlayerModel();
            playerModel.personID = person.PersonID;
            playerModel.firstName = person.FirstName;
            playerModel.middleName = person.MiddleName;
            playerModel.lastName = person.LastName;
            playerModel.mobile = person.Mobile;
            playerModel.email = person.Email;
            return playerModel;
        }
    }
}