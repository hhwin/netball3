
namespace ClassLibrary.Logic.Coach
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System;
    using ClassLibrary.Database;

    /// <summary>
    /// Get coach details including person details.
    /// </summary>
    public class CoachSelect : ICoachSelect
    {
        public Coach GetCoach(int coachID)
        {
            Coach coach = new Coach();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    coach = context.Coaches
                        .Include(c => c.Person)
                        .Where(c => c.CoachID == coachID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coach;
        }

        public IList<Coach> GetCoachList()
        {
            IList<Coach> coachList = new List<Coach>();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    coachList = context.Coaches
                        .Include(c => c.Person)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return coachList;
        }    
    }
}

//private IList<Person>GetPeople (SqlConnection connection)
//{
//    IList<Person> personList = new List<Person>();
//    using (connection)
//    {
//        SqlCommand command = new SqlCommand(
//          "SELECT PersonID, FirstName, LastName FROM Person;",
//          connection);
//        connection.Open();

//        SqlDataReader reader = command.ExecuteReader();

//        if (reader.HasRows)
//        {
//            while (reader.Read())
//            {
//                Person person = new Person();
//                person.PersonID = reader.GetInt32(0);
//                person.FirstName = reader.GetString(1);
//                person.LastName = reader.GetString(2);

//                personList.Add(person);
//            }
//        }
//        reader.Close();

//        return personList;
//    }        
