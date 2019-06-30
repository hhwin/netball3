using ClassLibrary.Database;

namespace ClassLibrary.Logic.PersonLogic
{
    public interface IPersonDelete
    {
        void PersonRemove(Person person);
        void PersonRemove(int personID);
    }
}