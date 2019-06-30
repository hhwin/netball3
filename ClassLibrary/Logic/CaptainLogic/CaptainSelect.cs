using ClassLibrary.Models;
using System;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Database;

namespace ClassLibrary.Logic.CaptainLogic
{
    public class CaptainSelect : ICaptainSelect
    {
        public PlayerModel GetCaptain(int teamID)
        {
            PlayerModel playerModel = new PlayerModel();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    playerModel = context.TeamPlayers
                        .Include(t => t.Person)
                        .Include(t => t.Team)
                        .Where(t => t.TeamID == teamID && t.Team.CaptainID != null)
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
                            captain = true,
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