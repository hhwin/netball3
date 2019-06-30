using ClassLibrary.Database;
using ClassLibrary.Models;
using System;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Logic.Team;
using ClassLibrary.Logic.PersonLogic;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class GetCoachModelLogic : IGetCoachModelLogic
    {
        private IPersonSelect _personSelect;
        private ITeamSelectLogic _teamSelectLogic;

        public GetCoachModelLogic(ITeamSelectLogic teamSelectLogic,
            IPersonSelect personSelect)
        {
            _teamSelectLogic = teamSelectLogic;
            _personSelect = personSelect;
        }
        public CoachModel GetActiveCoachModel(int coachPersonID,
            int teamID)
        {
            CoachModel coachModel = new CoachModel();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    coachModel =  context.Coaches
                        .Include(c => c.Person)
                        .Include(c => c.Team)
                        .Where(c => c.TeamID == c.Team.TeamID && c.CoachPersonID == c.Person.PersonID && c.ActiveInd)
                        .Select(m => new CoachModel
                        {
                            personID = m.Person.PersonID,
                            teamID = m.TeamID,
                            firstName = m.Person.FirstName,
                            middleName = m.Person.MiddleName,
                            lastName = m.Person.LastName,
                            mobile = m.Person.Mobile,
                            email = m.Person.Email,
                            emergencyContact = m.Person.EmergencyContact,
                            emergencyContactNo = m.Person.EmergencyContactNo,
                            teamName = m.Team.TeamName,
                            coachName = m.Person.FirstName + " " + m.Person.LastName,
                            activeInd = m.ActiveInd
                        })
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachModel;
        }
        public CoachModel GetActiveCoachModel(int teamID)
        {
            CoachModel coachModel = new CoachModel();
            Database.Team team = new Database.Team();
            Person person = new Person();

            try
            {
                team = _teamSelectLogic.GetTeam(teamID);

                if (team != null)
                {
                    person = _personSelect.GetPerson(team.CoachID ?? 0);
                    coachModel.activeInd = true;
                    coachModel.captainID = team.CaptainID;

                    if (person != null)
                    {
                        coachModel.coachName = (person.FirstName + " " + person.LastName).Trim();
                        coachModel.email = person.Email;
                        coachModel.emergencyContact = person.EmergencyContact;
                        coachModel.emergencyContactNo = person.EmergencyContactNo;
                        coachModel.firstName = person.FirstName;
                        coachModel.lastName = person.LastName;
                        coachModel.middleName = person.MiddleName;
                        coachModel.mobile = person.Mobile;
                    }
                    coachModel.divisionID = team.DivisionID;
                    coachModel.personID = team.CoachID ?? 0;
                    coachModel.teamID = teamID;
                    coachModel.teamName = team.TeamName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachModel;
        }
    }
}