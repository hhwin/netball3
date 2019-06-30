using ClassLibrary.Models;
using PagedList;
using System.Threading.Tasks;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public interface IAwardModelPagedList
    {
        Task<IPagedList<AwardModel>> GetPagedList(int awardID, int? page, int pageSize = 6);
    }
}