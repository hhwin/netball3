namespace ClassLibrary.Logic.PersonLogic
{
    public interface IPersonUpdate
    {
        int? PersonUpdateTransaction(Database.Person person);
    }
}