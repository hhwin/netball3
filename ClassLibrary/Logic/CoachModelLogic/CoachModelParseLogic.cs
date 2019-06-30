using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class CoachModelParseLogic : ICoachModelParseLogic
    {
        public Person ParsePerson(CoachModel coachModel)
        {
            Person person = new Person();

            person.Email = coachModel.email;
            person.EmergencyContact = coachModel.emergencyContact;
            person.EmergencyContactNo = coachModel.emergencyContactNo;
            person.FirstName = coachModel.firstName;
            person.LastName = coachModel.lastName;
            person.MiddleName = coachModel.middleName;
            person.Mobile = coachModel.mobile;
            person.PersonID = coachModel.personID;
            return person;
        }
        public CoachModel ParseCoachModel(Person person)
        {
            CoachModel coachModel = new CoachModel();

            coachModel.email = person.Email;
            coachModel.emergencyContact = person.EmergencyContact;
            coachModel.emergencyContactNo = person.EmergencyContactNo;
            coachModel.firstName = person.FirstName;
            coachModel.lastName = person.LastName;
            coachModel.middleName = person.MiddleName;
            coachModel.mobile = person.Mobile;
            coachModel.personID = person.PersonID;
            return coachModel;
        }

        public Database.Coach ParseCoach(CoachModel coachModel)
        {
            Database.Coach coach = new Database.Coach();
            coach.CoachID = 0;
            coach.CoachPersonID = coachModel.personID;
            coach.TeamID = coachModel.teamID;
            return coach;    
        }
    }
}