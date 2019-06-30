namespace ClassLibrary.Logic.GameTeamLogic
{
    using ClassLibrary.Database;
    using System;
    using System.Data.Entity;

    public class GameTeamInsert : IGameTeamInsert
    {
        /// <summary>
        /// Insert a GameTeam object in GameTeam table returning GameTeamID if successful.
        /// GameTeamID = null if failed.
        /// </summary>
        /// <param name="GameTeam"></param>
        /// <returns></returns>
        public int? GameTeamAdd(GameTeam gameteam)
        {
            int? gameteamID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gameteam).State = EntityState.Added;
                    context.SaveChanges();
                    gameteamID = gameteam.GameTeamID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameteamID;
        }
    }
}
