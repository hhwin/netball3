using ClassLibrary.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.TeamModelLogic
{
    public class TeamModelListLogic : ITeamModelListLogic
    {
        /// <summary>
        /// Get team model list for a given team ID.
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns></returns>
        public IList<TeamModel> GetTeamModelList(int? teamID)
        {
            IList<TeamModel> teamModelList = new List<TeamModel>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    teamModelList = context.Teams
                        .AsNoTracking()
                        .Select(t => new TeamModel
                        {
                            teamID = t.TeamID,
                            teamName = t.TeamName,
                            coachName = t.Person.FirstName + " " + t.Person.LastName,
                            coachPersonID = t.CoachID ?? 0,
                            divisionID = t.DivisionID ?? 0,
                            divisionName = t.Division.Division1,
                            captainID = t.CaptainID??0,
                            captainName = t.Person1.FirstName + " " + t.Person1.LastName
                        })
                        .OrderBy(t => t.teamName)
                        .ToList();

                    if (teamID != null && teamID > 0)
                    {
                        teamModelList = teamModelList
                            .Where(t => t.teamID == teamID)
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamModelList;
        }
        public IList<TeamModel> GetTeamModelList(string teamName)
        {
            IList<TeamModel> teamModelList = new List<TeamModel>();
            using (NetballEntities context = new NetballEntities())
            {
                teamModelList = context.Teams
                    .AsNoTracking()
                    .Where(t => t.TeamName.ToLower().Contains(teamName.ToLower()))
                    .Select(t => new TeamModel
                    {
                        teamID = t.TeamID,
                        teamName = t.TeamName,
                        coachName = t.Person.FirstName + " " + t.Person.LastName,
                        coachPersonID = t.CoachID ?? 0,
                        divisionID = t.DivisionID ?? 0,
                        divisionName = t.Division.Division1,
                        captainID = t.CaptainID??0,
                        captainName = t.Person1.FirstName + " " + t.Person1.LastName
                    })
                    .OrderBy(t => t.teamName)
                    .ToList();
            }
            return teamModelList;
        }
    }
}