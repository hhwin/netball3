
namespace ClassLibrary.Logic.GameTeamLogic
{
    using System;
    using ClassLibrary.Database;
    using System.Data.Entity;

    public class GameTeamUpdate : IGameTeamUpdate
    {
        public int? GameTeamUpdateTransaction(GameTeam gameteam)
        {
            int? gameteamID = null;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    context.Entry(gameteam).State = EntityState.Modified;
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
