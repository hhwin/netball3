namespace ClassLibrary.Logic.Division
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class DivisionDelete : IDivisionDelete
    {
        /// <summary>          
        /// Deletes a given Division object.           
        /// </summary>          
        /// <param name="Division"></param>            
        public void DivisionRemove(Division division)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(division).State = EntityState.Deleted; context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}