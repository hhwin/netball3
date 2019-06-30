using ClassLibrary.Models;

namespace ClassLibrary.Logic.DivisionIndexModelLogic
{
    public interface IDivisionIndexModelSelectListLogic
    {
        DivisionIndexModel GetDivisionIndexModel(int? divisionID, int? page);
    }
}