using System;
using PagedList;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public interface IGameModelPagedListLogic
    {
        IPagedList GetGameModelPagedList(int teamID, int divisionID, DateTime? datePlayed, int? page);
    }
}