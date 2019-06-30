namespace ClassLibrary.Logic.Game
{
    public interface IGameUpdate
    {
        int? GameUpdateTransaction(Database.Game game);
    }
}