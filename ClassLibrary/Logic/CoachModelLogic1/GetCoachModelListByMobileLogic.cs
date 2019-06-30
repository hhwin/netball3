using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public class GetCoachModelListByMobileLogic : IGetCoachModelListByMobileLogic
    {
        public IList<CoachModel>GetCoachModelListByMobile(string mobile)
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            using (NetballEntities context = new NetballEntities())
            {
                coachModelList = context.Teams
                    .Include(c => c.Person)
                    .Where(c => c.Person.Mobile.Contains(mobile))
                    .Select(c => new CoachModel
                    {
                        captainID = c.CaptainID,
                        coachName = c.Person.FirstName + " " + c.Person.LastName,
                        divisionID = c.DivisionID,
                        email = c.Person.Email,
                        emergencyContact = c.Person.EmergencyContact,
                        emergencyContactNo = c.Person.EmergencyContactNo,
                        firstName = c.Person.FirstName,
                        lastName = c.Person.LastName,
                        middleName = c.Person.MiddleName,
                        mobile = c.Person.Mobile,
                        personID = c.Person.PersonID,
                        teamID = c.TeamID,
                        teamName = c.TeamName
                    })
                    .ToList();
            }
            return coachModelList;
        }
    }
}
