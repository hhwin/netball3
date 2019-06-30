namespace ClassLibrary.Logic.GamePlayerLogic
{
    public interface IGamePlayerUpdate
    {
        int? GamePlayerUpdateTransaction(Database.GamePlayer gameplayer);
    }
}