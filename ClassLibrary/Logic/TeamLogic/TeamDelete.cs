
namespace ClassLibrary.Logic.Team
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class TeamDelete : ITeamDelete
    {
        /// <summary>
        /// Deletes a given Team object. 
        /// </summary>
        /// <param name="Team"></param> 

        public void TeamRemove(Team team)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(team).State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
