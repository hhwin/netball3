using ClassLibrary.Model;
using PagedList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class PlayerMatchModel : AbstractPersonModel, IPersonModel
    {
        public override string GetPersonName(string firstName, string lastName)
        {
            return (firstName + ' ' + lastName).Trim();
        }
        [Display(Name="Player Name")]
        public string playerName;
        public IPagedList<GameMatchModel> gameMatchPagedList;
        public IList<GameMatchModel> gameMatchModelList;
    }
}
