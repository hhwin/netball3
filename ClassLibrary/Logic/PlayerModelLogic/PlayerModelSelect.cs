using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    /// <summary>
    /// Get player model object for given person ID (and team ID - optional)
    /// Returns IList because person can be on multiple teams.
    /// </summary>
    public class PlayerModelSelect : IPlayerModelSelect
    {
        public IList<PlayerModel> GetPlayerModelList(int personID)
        {
            IList<PlayerModel> list = new List<PlayerModel>();
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    list = context.TeamPlayers
                        .Include(t => t.Person)
                        .Include(t => t.Team)
                        .Where(t => t.PlayerID == personID)
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
                            captain = t.CaptainInd,
                            teamName = t.Team.TeamName,
                            playerName = t.Person.FirstName + " " + t.Person.LastName
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public PlayerModel GetPlayerModel(int personID, int teamID)
        {
            PlayerModel playerModel = new PlayerModel();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    playerModel = context.TeamPlayers
                        .Include(p => p.Person)
                        .Include(p => p.Team)
                        .Where(p => p.Person.PersonID == personID)
                        .Where(p => p.TeamID == teamID && p.PlayerID == personID)
                        .Select(p => new PlayerModel
                        {
                            personID = p.PlayerID,
                            teamID = p.TeamID,
                            firstName = p.Person.FirstName,
                            middleName = p.Person.MiddleName,
                            lastName = p.Person.LastName,
                            mobile = p.Person.Mobile,
                            email = p.Person.Email,
                            emergencyContact = p.Person.EmergencyContact,
                            emergencyContactNo = p.Person.EmergencyContactNo,
                            captain = p.CaptainInd,
                            teamName = p.Team.TeamName,
                            playerName = p.Person.FirstName + " " + p.Person.LastName
                        })
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return playerModel;
        }
        public PlayerModel GetPlayerModel(string firstName, string lastName)
        {
            PlayerModel playerModel = new PlayerModel();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    playerModel = context.TeamPlayers
                        .Include(p => p.Person)
                        .Include(p => p.Team)
                        .Where(p => p.Person.FirstName.ToLower() == firstName.ToLower())
                        .Where(p => p.Person.LastName.ToLower() == lastName.ToLower())
                        .Select(p => new PlayerModel
                        {
                            personID = p.PlayerID,
                            teamID = p.TeamID,
                            firstName = p.Person.FirstName,
                            middleName = p.Person.MiddleName,
                            lastName = p.Person.LastName,
                            mobile = p.Person.Mobile,
                            email = p.Person.Email,
                            emergencyContact = p.Person.EmergencyContact,
                            emergencyContactNo = p.Person.EmergencyContactNo,
                            captain = p.CaptainInd,
                            teamName = p.Team.TeamName,
                            playerName = p.Person.FirstName + " " + p.Person.LastName
                        })
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return playerModel;
        }
    }
}