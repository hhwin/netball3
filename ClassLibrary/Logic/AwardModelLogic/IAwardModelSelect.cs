using System.Threading.Tasks;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public interface IAwardModelSelect
    {
        Task<AwardModel> GetAwardModel(int awardID);
        Task<AwardModel> GetAwardModelByAwardName(string awardName);
    }
}