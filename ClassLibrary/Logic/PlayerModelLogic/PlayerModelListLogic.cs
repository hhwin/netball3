using ClassLibrary.Database;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public class PlayerModelListLogic : IPlayerModelListLogic
    {
        public IList<PlayerModel> BasePlayerModelList()
        {
            IList<PlayerModel> list = new List<PlayerModel>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    list = context.TeamPlayers
                        .Include(t => t.Person)
                        .Include(t => t.Team)
                        .ToList()
                        .Select(t => new PlayerModel
                        {
                            personID = t.Person.PersonID,
                            teamID = t.TeamID,
                            firstName = t.Person.FirstName,
                            middleName = t.Person.MiddleName,
                            lastName = t.Person.LastName,
                            mobile = t.Person.Mobile,
                            email = t.Person.Email,
                            emergencyContact = t.Person.EmergencyContact,
                            emergencyContactNo = t.Person.EmergencyContactNo,
                            teamName = t.Team.TeamName,
                            //captain = (t.Team.CaptainID == t.Person.PersonID),
                            captain = t.CaptainInd,
                            playerName = t.Person.FirstName + " " + t.Person.LastName
                        })
                        .OrderBy(t => t.teamName)
                        .ThenBy(t => t.playerName)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public IList<PlayerModel>GetPlayerModelList(int teamID)
        {
            IList<PlayerModel> list = new List<PlayerModel>();
            list = BasePlayerModelList();

            if (list != null)
            {
                list = list
                    .Where(t => t.teamID == teamID)
                    .ToList();
            }
            return list;
        }
        public IList<PlayerModel> GetPlayerModelList(string playerName)
        {
            IList<PlayerModel> list = new List<PlayerModel>();
            list = BasePlayerModelList();

            if (list != null && playerName != null)
            {
                list = list
                    .Where(t => t.playerName.ToLower().Contains(playerName.Trim().ToLower()))
                    .ToList();
            }
            return list;
        }
        public IList<PlayerModel> GetPlayerModelList(int teamID, string playerName)
        {
            IList<PlayerModel> list = new List<PlayerModel>();
            list = BasePlayerModelList();

            if (list != null)
            {
                list = list
                    .Where(t => t.teamID == teamID && t.playerName.ToLower().Contains(playerName.Trim().ToLower()))
                    .ToList();
            }
            return list;
        }
    }
}