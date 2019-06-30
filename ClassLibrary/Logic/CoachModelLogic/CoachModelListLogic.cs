using ClassLibrary.Database;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class CoachModelListLogic : ICoachModelListLogic
    {
        /// <summary>
        /// Get coach model list with a right outer join of people. (So all people are selected even if they are not a coach).
        /// </summary>
        /// <returns></returns>
        public IList<CoachModel> GetCoachModelList()
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    var list = (from p in context.People
                                from t in context.Teams
                                //from c in context.Coaches
                                .Where(t => t.CoachID == p.PersonID)
                                //.Where(c => c.ActiveInd == true && t.CoachID == c.CoachID)
                                .DefaultIfEmpty()
                                select new CoachModel
                                {
                                    personID = p.PersonID,
                                    //teamID = t.TeamID,
                                    firstName = p.FirstName,
                                    middleName = p.MiddleName,
                                    lastName = p.LastName,
                                    mobile = p.Mobile,
                                    email = p.Email,
                                    emergencyContact = p.EmergencyContact,
                                    emergencyContactNo = p.EmergencyContactNo,
                                    teamName = t.TeamName,
                                    coachName = p.FirstName + " " + p.LastName
                                    //activeInd = c.ActiveInd
                                })
                                 .OrderBy(m => m.coachName);

                    coachModelList = list
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachModelList;
        }

        
    }
}