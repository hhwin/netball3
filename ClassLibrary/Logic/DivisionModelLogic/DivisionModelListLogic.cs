using ClassLibrary.Database;
using ClassLibrary.Logic.CaptainLogic;
using ClassLibrary.Logic.CoachModelLogic;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary.Logic.DivisionModelLogic
{
    public class DivisionModelListLogic : IDivisionModelListLogic
    {
        private ICaptainSelect _captainSelect;
        private IGetCoachModelLogic _getCoachModelLogic;

        public DivisionModelListLogic()
        { }
        public DivisionModelListLogic(ICaptainSelect captainSelect,
            IGetCoachModelLogic getCoachModelLogic)
        {
            _captainSelect = captainSelect;
            _getCoachModelLogic = getCoachModelLogic;
        }
        private IList<DivisionModel>PopulateDivisionModel(IList<DivisionModel>divisionModelList)
        {
            PlayerModel playerModel = new PlayerModel();
            CoachModel coachModel = new CoachModel();

            foreach (DivisionModel divisionModel in divisionModelList)
            {
                playerModel = null;
                coachModel = null;
                playerModel = _captainSelect.GetCaptain(divisionModel.teamID);
                coachModel = _getCoachModelLogic.GetActiveCoachModel(divisionModel.teamID);

                if (playerModel != null)
                {
                    divisionModel.captain = playerModel.firstName + " " + playerModel.lastName;
                }
                if (coachModel != null)
                {
                    divisionModel.coach = coachModel.coachName;
                }
            }
            return divisionModelList;
        }
        public IList<DivisionModel> GetDivisionModelList()
        {
            IList<DivisionModel> divisionModelList = new List<DivisionModel>();

            using (NetballEntities context = new NetballEntities())
            {
                divisionModelList = context.Teams
                    .Include(t => t.Division)
                    .AsNoTracking()
                    .Select(t => new DivisionModel
                    {
                        divisionID = t.DivisionID ?? 0,
                        division = t.Division.Division1,
                        teamID = t.TeamID,
                        teamName = t.TeamName,
                        coachID = t.CoachID,
                        captainID = t.CaptainID
                    })
                    .OrderBy(t => t.divisionID)
                    .ThenBy(t => t.teamName)
                    .ToList();
            }
            return PopulateDivisionModel(divisionModelList);
        }
        public IList<DivisionModel>GetDivisionModelList(int divisionID)
        {
            IList<DivisionModel> divisionModelList = new List<DivisionModel>();

            using (NetballEntities context = new NetballEntities())
            {
                divisionModelList = context.Teams
                    .Include(t => t.Division)
                    .AsNoTracking()
                    .Where(t => t.DivisionID == divisionID)
                    .Select(t => new DivisionModel
                    {
                        divisionID = (int)t.DivisionID,
                        division = t.Division.Division1,
                        teamID = t.TeamID,
                        teamName = t.TeamName,
                        coachID = t.CoachID,
                        captainID = t.CaptainID
                    })
                    .OrderBy(t => t.teamName)
                    .ToList();
            }
            return PopulateDivisionModel(divisionModelList);
        }
    }
}
