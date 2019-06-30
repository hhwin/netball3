namespace ClassLibrary.Logic.GamePlayerLogic
{
    public interface IGamePlayerDelete
    {
        void GamePlayerRemove(Database.GamePlayer gameplayer);
        void GamePlayerRemove(int gamePlayerID);
    }
}