using ClassLibrary.Database;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GamePlayerLogic
{
    public interface IGamePlayerParse
    {
        GamePlayer GamePlayerParseLogic(GameTeamPlayerModel gameTeamPlayerModel);
    }
}