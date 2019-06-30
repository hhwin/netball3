namespace ClassLibrary.Logic.GameTeamLogic
{
    public interface IGameTeamUpdate
    {
        int? GameTeamUpdateTransaction(Database.GameTeam gameteam);
    }
}