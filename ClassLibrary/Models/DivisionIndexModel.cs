using PagedList;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class DivisionIndexModel
    {
        [Required]
        public int? DivisionID { get; set; }
        [Required]
        public string Division { get; set; }
        public int? pageCount { get; set; }
        public IPagedList<DivisionModel> divisionModelPagedList { get; set; }
    }
}
