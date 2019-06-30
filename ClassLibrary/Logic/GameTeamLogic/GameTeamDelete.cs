
namespace ClassLibrary.Logic.GameTeamLogic
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class GameTeamDelete : IGameTeamDelete
    {
        /// <summary>
        /// Deletes a given GameTeam object. 
        /// </summary>
        /// <param name="GameTeam"></param> 

        public void GameTeamRemove(GameTeam gameteam)
        {
            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gameteam).State = EntityState.Deleted;
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
