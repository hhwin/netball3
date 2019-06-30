using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Logic.AwardLogic
{
    public interface IAwardDelete
    {
        void AwardDeleteTransaction(Database.Award award);
        void AwardDeleteTransaction(int awardID);
    }
}
