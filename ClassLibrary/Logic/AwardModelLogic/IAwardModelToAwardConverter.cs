using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Logic.AwardModelLogic
{
    public interface IAwardModelToAwardConverter
    {
        Database.Award ConvertToAward(AwardModel awardModel);
    }
}
