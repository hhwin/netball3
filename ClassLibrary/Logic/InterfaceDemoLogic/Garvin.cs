namespace ClassLibrary.Logic.InterfaceDemoLogic
{
    public class Garvin : IPeople
    {
        public int MyID()
        {
            return 456;
        }

        public string MyName()
        {
            return "Hi my name is Garvin";
        }

        public string MyOccuptaion()
        {
            return "I don't know what I am doing";
        }
    }
}
