using ClassLibrary.Database;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Models;
using ClassLibrary.Logic.PersonLogic;
using System;

namespace ClassLibrary.Logic.TeamModelLogic
{
    public class TeamModelListByDivisionLogic : ITeamModelListByDivisionLogic
    {
        private IPersonSelect _personSelect;

        public TeamModelListByDivisionLogic(IPersonSelect personSelect)
        {
            _personSelect = personSelect;
        }
        public IList<TeamModel>GetTeamModeListByDivision(int divisionID)
        {
            IList<TeamModel> teamModelList = new List<TeamModel>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    teamModelList = context.TeamPlayers
                        .AsNoTracking()
                        .Include(t => t.Team)
                        .Include(t => t.Person)
                        .Include(t => t.Team.Division)
                        .Where(t => t.Team.DivisionID == divisionID)
                        .Select(t => new TeamModel
                        {
                            teamID = t.TeamID,
                            playerID = t.PlayerID,
                            teamName = t.Team.TeamName,
                            coachPersonID = t.Team.CoachID ?? 0,
                            divisionID = t.Team.DivisionID ?? 0,
                            divisionName = t.Team.Division.Division1,
                            captainID = t.Team.CaptainID ?? 0,
                            playerName = t.Person.FirstName + " " + t.Person.LastName
                        })
                        .OrderBy(t => t.playerName)
                        .ToList();
                }
                foreach (TeamModel teamModel in teamModelList)
                {
                    if (teamModel.coachPersonID != 0)
                    {
                        Person coach = new Person();
                        coach = _personSelect.GetPerson(teamModel.coachPersonID);
                        if (coach != null)
                        {
                            teamModel.coachName = coach.FirstName + " " + coach.LastName;
                        }
                    }
                    if (teamModel.captainID != 0)
                    {
                        Person captain = new Person();
                        captain = _personSelect.GetPerson(teamModel.captainID);
                        if (captain != null)
                        {
                            teamModel.captainName = captain.FirstName + " " + captain.LastName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamModelList;
        }
        public IList<TeamModel> GetTeamModeListBasicsByDivision(int divisionID)
        {
            IList<TeamModel> teamModelList = new List<TeamModel>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    teamModelList = context.TeamPlayers
                        .AsNoTracking()
                        .Include(t => t.Team)
                        .Include(t => t.Person)
                        .Include(t => t.Team.Division)
                        .Where(t => t.Team.DivisionID == divisionID)
                        .Where(t => t.Team.CaptainID == t.Person.PersonID || 
                        t.Team.CoachID == t.Person.PersonID)
                        .Select(t => new TeamModel
                        {
                            teamID = t.TeamID,
                            playerID = t.PlayerID,
                            teamName = t.Team.TeamName,
                            coachPersonID = t.Team.CoachID ?? 0,
                            divisionID = t.Team.DivisionID ?? 0,
                            divisionName = t.Team.Division.Division1,
                            captainID = t.Team.CaptainID ?? 0,
                            playerName = t.Person.FirstName + " " + t.Person.LastName
                        })
                        .OrderBy(t => t.playerName)
                        .ToList();
                }
                foreach (TeamModel teamModel in teamModelList)
                {
                    if (teamModel.coachPersonID != 0)
                    {
                        Person coach = new Person();
                        coach = _personSelect.GetPerson(teamModel.coachPersonID);
                        if (coach != null)
                        {
                            teamModel.coachName = coach.FirstName + " " + coach.LastName;
                        }
                    }
                    if (teamModel.captainID != 0)
                    {
                        Person captain = new Person();
                        captain = _personSelect.GetPerson(teamModel.captainID);
                        if (captain != null)
                        {
                            teamModel.captainName = captain.FirstName + " " + captain.LastName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return teamModelList;
        }
    }
}
