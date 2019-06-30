using ClassLibrary.Models;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    using ClassLibrary.Database;

    public interface IPlayerModelParse
    {
        Person ParsePerson(PlayerModel playerModel);
        PlayerModel ParsePlayerModel(Person person);
    }
}