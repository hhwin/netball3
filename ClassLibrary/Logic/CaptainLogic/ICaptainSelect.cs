using ClassLibrary.Models;

namespace ClassLibrary.Logic.CaptainLogic
{
    public interface ICaptainSelect
    {
        PlayerModel GetCaptain(int teamID);
    }
}