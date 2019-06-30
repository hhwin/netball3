namespace ClassLibrary.Logic.PlayerModelLogic
{
    public interface IPlayerModelDeleteLogic
    {
        void PlayerModelDelete(int playerID, int teamID, ref string message);
    }
}