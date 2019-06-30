using System.Collections.Generic;
using System.Web.Mvc;
using ClassLibrary.Database;

namespace ClassLibrary.Logic.PersonLogic
{
    public class PersonSelectListLogic : PersonSelect
    {
        public List<SelectListItem> GetPersonSelectList(int personID = 0,
            string text = "-- Select person --")
        {
            List<SelectListItem> personItem = new List<SelectListItem>();
            IList<Person> personList = GetPersonList();

            personItem.Add(new SelectListItem
            {
                Text = text,
                Value = "0",
                Selected = (personID == 0)
            });

            foreach (Person person in personList)
                personItem.Add(new SelectListItem
                {
                    Text = person.FirstName + " " + person.LastName,
                    Value = person.PersonID.ToString(),
                    Selected = (person.PersonID == personID)
                });

            return personItem;
        }

        public static List<SelectListItem> GetPersonSelectListStatic(int personID,
            string text = "-- Select Person --")
        {
            PersonSelectListLogic personSelectListLogic = new PersonSelectListLogic();
            return personSelectListLogic.GetPersonSelectList(personID, text);
        }
    }
}
