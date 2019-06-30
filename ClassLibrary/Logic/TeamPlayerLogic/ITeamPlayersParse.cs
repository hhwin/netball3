using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public interface ITeamPlayersParse
    {
        TeamPlayer ParsePlayerModel(PlayerModel playerModel);
    }
}