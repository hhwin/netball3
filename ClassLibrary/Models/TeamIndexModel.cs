using PagedList;

namespace ClassLibrary.Models
{
    public class TeamIndexModel
    {
        public int teamID { get; set; }
        public string teamName { get; set; }
        public IPagedList<TeamModel> TeamPagedList { get; set; }
    }
}
