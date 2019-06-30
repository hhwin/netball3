namespace ClassLibrary.Logic.InterfaceDemoLogic
{
    public class HtayHtay : IPeople
    {
        public string MyName()
        {
            return "Hi. My name is Htay Htay";
        }
        public string MyOccuptaion()
        {
            return "I am an MVC devloper.";
        }
        public int MyID()
        {
            return 123;
        }
        public string Gender()
        {
            return "I am a woman";
        }
    }
}
