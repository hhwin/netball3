using ClassLibrary.Database;
using ClassLibrary.Logic.GameMatchModelLogic;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;

namespace ClassLibrary.Logic.PlayerMatchModelLogic
{
    public class PlayerMatchModelSelect : IPlayerMatchModelSelect
    {
        private IPersonSelect _personSelect;
        private IGameMatchModelSelectLogic _gameMatchModelSelectLogic;

        public PlayerMatchModelSelect(IPersonSelect personSelect,
            IGameMatchModelSelectLogic gameMatchModelSelectLogic)
        {
            _personSelect = personSelect;
            _gameMatchModelSelectLogic = gameMatchModelSelectLogic;
        }
        private IList<GameMatchModel>GetGameMatchList(int playerID)
        {
            return _gameMatchModelSelectLogic.GetGameMatchModelList(playerID);
        }
        public IPagedList<GameMatchModel>GetGameMatchPagedList(int playerID,
            int? pageNumber,
            int? pageSize = 10)
        {
            int page = pageNumber ?? 1;
            pageSize = pageSize ?? 10;
            return _gameMatchModelSelectLogic.GetGameMatchModelList(playerID).ToPagedList(page, (int)pageSize);
        }
        public PlayerMatchModel GetPlayerMatchModel(int personID,
            int? pageNumber,
            int? pageSize)
        {
            PlayerMatchModel playerMatchModel = new PlayerMatchModel();
            Person person;
            person = _personSelect.GetPerson(personID);

            if (person != null)
            {
                playerMatchModel.email = person.Email;
                playerMatchModel.emergencyContact = person.EmergencyContact;
                playerMatchModel.emergencyContactNo = person.EmergencyContactNo;
                playerMatchModel.firstName = person.FirstName;
                playerMatchModel.lastName = person.LastName;
                playerMatchModel.middleName = person.MiddleName;
                playerMatchModel.mobile = person.Mobile;
                playerMatchModel.personID = person.PersonID;
                playerMatchModel.playerName = (person.FirstName + " " + person.LastName).Trim();
                playerMatchModel.gameMatchModelList = GetGameMatchList(personID);
                playerMatchModel.gameMatchPagedList = GetGameMatchPagedList(personID, pageNumber, pageSize);
            }
            return playerMatchModel;
        }
    }
}
