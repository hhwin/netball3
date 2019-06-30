using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.AwardLogic.AwardModelLogic
{
    public interface IAwardModelSelectList
    {
        Task<IList<AwardModel>> GetAwardModelList();
        Task<IList<AwardModel>> GetAwardModelList(bool activeInd = true);
        Task<IList<AwardModel>> GetAwardModelList(int? awardID);
    }
}