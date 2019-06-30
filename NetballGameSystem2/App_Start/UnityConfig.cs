using ClassLibrary.Logic.AwardLogic;
using ClassLibrary.Logic.AwardModelLogic;

using ClassLibrary.Logic.CaptainLogic;
using ClassLibrary.Logic.Coach;
using ClassLibrary.Logic.CoachModelLogic;
using ClassLibrary.Logic.CoachModelLogic1;
//using ClassLibrary.Logic.CoachModelLogic;
using ClassLibrary.Logic.Court;
using ClassLibrary.Logic.Division;
using ClassLibrary.Logic.DivisionIndexModelLogic;
using ClassLibrary.Logic.DivisionLogic;
using ClassLibrary.Logic.DivisionModelLogic;
//using ClassLibrary.Logic.Court;
//using ClassLibrary.Logic.Division;
//using ClassLibrary.Logic.DivisionLogic;
using ClassLibrary.Logic.Game;
using ClassLibrary.Logic.GameIndexModelLogic;
using ClassLibrary.Logic.GameMatchModelLogic;
using ClassLibrary.Logic.GameModelListLogic;
using ClassLibrary.Logic.GameModelLogic;
using ClassLibrary.Logic.GamePlayerLogic;
//using ClassLibrary.Logic.GameQuarter;
using ClassLibrary.Logic.GameTeamLogic;
using ClassLibrary.Logic.GameTeamModelLogic;
using ClassLibrary.Logic.GameTeamPlayerModelLogic;
using ClassLibrary.Logic.InterfaceDemoLogic;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Logic.PlayerIndexModelLogic;
using ClassLibrary.Logic.PlayerMatchModelLogic;
using ClassLibrary.Logic.PlayerModelLogic;
//using ClassLibrary.Logic.QuarterType;
using ClassLibrary.Logic.Team;
using ClassLibrary.Logic.TeamLogic;
using ClassLibrary.Logic.TeamModelLogic;
using ClassLibrary.Logic.TeamPlayerLogic;
using ClassLibrary.Logic.TeamPlayerModelLogic;
//using ClassLibrary.Logic.Tournament;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace NetballGameSystem2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICaptainSelect, CaptainSelect>();
            container.RegisterType<ICaptainSelectList, CaptainSelectList>();
            container.RegisterType<ICheckCaptainLogic, CheckCaptainLogic>();

            container.RegisterType<ICoachInsert, CoachInsert>();
            //container.RegisterType<ICoachSelect, CoachSelect>();
            //container.RegisterType<ICoachUpdate, CoachUpdate>();
            //container.RegisterType<ICoachDelete, CoachDelete>();

            //container.RegisterType<ICoachModelCheckLogic, CoachModelCheckLogic>();
            container.RegisterType<ICoachModelListLogic, CoachModelListLogic>();
            //container.RegisterType<ICoachModelParseLogic, CoachModelParseLogic>();
            //container.RegisterType<IGetCoachModelLogic, GetCoachModelLogic>();
            //container.RegisterType<ICoachModelInsertLogic, CoachModelInsertLogic>();
            //container.RegisterType<ICoachModelSelectLogic, CoachModelSelectLogic>();
            //container.RegisterType<ICoachModelSelectTeam, CoachModelSelectTeam>();
            //container.RegisterType<ICoachModelPageListLogic, CoachModelPagedListLogic>();

            container.RegisterType<IGetCoachModelLogic1, GetCoachModelLogic1>();
            container.RegisterType<ICoachModelSelectListLogic1, CoachModelSelectListLogic1>();
            container.RegisterType<ICoachModelPagedListLogic1, CoachModelPagedListLogic1>();
            container.RegisterType<IGetCoachModelListByEmailLogic, GetCoachModelListByEmailLogic>();
            container.RegisterType<IGetCoachModelListByMobileLogic, GetCoachModelListByMobileLogic>();
            container.RegisterType<IGetCoachModelListByNameLogic, GetCoachModelListByNameLogic>();
            container.RegisterType<IGetCoachModelListByTeamLogic, GetCoachModelListByTeamLogic>();

            //container.RegisterType<IGetCoachModelListLogic, GetCoachModelListLogic>();
            //container.RegisterType<ICourtInsert, CourtInsert>();
            container.RegisterType<ICourtSelect, CourtSelect>();
            //container.RegisterType<ICourtUpdate, CourtUpdate>();
            //container.RegisterType<ICourtDelete, CourtDelete>();

            //container.RegisterType<IDivisionInsert, DivisionInsert>();
            container.RegisterType<IDivisionIndexModelSelectListLogic, DivisionIndexModelSelectListLogic>();
            container.RegisterType<IDivisionModelListLogic, DivisionModelListLogic>();
            container.RegisterType<IDivisionModelPagedListLogic, DivisionModelPagedListLogic>();
            container.RegisterType<IDivisionSelect, DivisionSelect>();
            //container.RegisterType<IDivisionUpdate, DivisionUpdate>();
            //container.RegisterType<IDivisionDelete, DivisionDelete>();
            container.RegisterType<IDivisionSelectList, DivisionSelectList>();

            //container.RegisterType<IGameDelete, GameDelete>();
            container.RegisterType<IGameInsert, GameInsert>();
            container.RegisterType<IGameParse, GameParse>();
            //container.RegisterType<IGameSelect, GameSelect>();
            container.RegisterType<IGameUpdate, GameUpdate>();

            container.RegisterType<IGameIndexModelParameterLogic, GameIndexModelParameterLogic>();
            container.RegisterType<IGameMatchModelSelectLogic, GameMatchModelSelectLogic>();       
            container.RegisterType<IGameModelCheckDuplicateLogic, GameModelCheckDuplicateLogic>();
            container.RegisterType<IGameModelCheckLogic, GameModelCheckLogic>();
            container.RegisterType<IGameModelCheckTeams, GameModelCheckTeams>();
            container.RegisterType<IGameModelDetailLogic, GameModelDetailLogic>();
            container.RegisterType<IGameModelInsertLogic, GameModeIInsertLogic>();
            //container.RegisterType<IGameModelListByDivisionLogic, GameModelListByDivisionLogic>();
            //container.RegisterType<IGameModelListByTeamLogic, GameModelListByTeamLogic>();
            container.RegisterType<IGameModelListLogic, GameModelListLogic>();
            container.RegisterType<IGameModelListParameterLogic, GameModelListParameterLogic>();
            container.RegisterType<IGameModelPagedListLogic, GameModelPagedListLogic>();
            container.RegisterType<IGameModelSelectLogic, GameModelSelectLogic>();
            container.RegisterType<IGameModelUpdateLogic, GameModelUpdateLogic>();

            container.RegisterType<IGamePlayerInsert, GamePlayerInsert>();
            container.RegisterType<IGamePlayerSelect, GamePlayerSelect>();
            container.RegisterType<IGamePlayerUpdate, GamePlayerUpdate>();
            container.RegisterType<IGamePlayerDelete, GamePlayerDelete>();
            container.RegisterType<IGamePlayerParse, GamePlayerParse>();

            //container.RegisterType<IGameQuarterInsert, GameQuarterInsert>();
            //container.RegisterType<IGameQuarterSelect, GameQuarterSelect>();
            //container.RegisterType<IGameQuarterUpdate, GameQuarterUpdate>();
            //container.RegisterType<IGameQuarterDelete, GameQuarterDelete>();

            container.RegisterType<IGameTeamInsert, GameTeamInsert>();
            container.RegisterType<IGameTeamParse, GameTeamParse>();
            container.RegisterType<IGameTeamSelect, GameTeamSelect>();
            container.RegisterType<IGameTeamUpdate, GameTeamUpdate>();
            //container.RegisterType<IGameTeamDelete, GameTeamDelete>();

            container.RegisterType<IGameTeamModelSelect, GameTeamModelSelect>();
            container.RegisterType<IGameTeamModelSelectList, GameTeamModelSelectList>();

            container.RegisterType<IGameTeamPlayerModelCheck, GameTeamPlayerModelCheck>();
            container.RegisterType<IGameTeamPlayerModelDelete, GameTeamPlayerModelDelete>();
            container.RegisterType<IGameTeamPlayerModelInsert, GameTeamPlayerModelInsert>();
            container.RegisterType<IGameTeamPlayerModelSelect, GameTeamPlayerModelSelect>();
            container.RegisterType<IGameTeamPlayerModelSelectList, GameTeamPlayerModelSelectList>();
            container.RegisterType<IGameTeamPlayerModelUpdate, GameTeamPlayerModelUpdate>();
            container.RegisterType<IGameTeamPlayerModelPagedList, GameTeamPlayerModelPagedList>();

            container.RegisterType<IGameIndexModelInitialiseLogic, GameIndexModelInitialiseLogic>();

            container.RegisterType<IPersonInsert, PersonInsert>();
            container.RegisterType<IPersonSelect, PersonSelect>();
            container.RegisterType<IPersonUpdate, PersonUpdate>();
            //container.RegisterType<IPersonDelete, PersonDelete>();

            container.RegisterType<IPlayerIndexModelSelectLogic, PlayerIndexModelSelectLogic>();
            container.RegisterType<IPlayerMatchModelSelect, PlayerMatchModelSelect>();
            container.RegisterType<IPlayerModelInsertLogic, PlayerModelInsertLogic>();
            container.RegisterType<IUpdatePlayerModelLogic, UpdatePlayerModelLogic>();
            container.RegisterType<IPlayerModelCheckLogic, PlayerModelCheckLogic>();
            container.RegisterType<IPlayerModelListLogic, PlayerModelListLogic>();
            container.RegisterType<IPlayerModelParse, PlayerModelParse>();
            container.RegisterType<IPlayerModelPageList, PlayerModelPageList>();
            container.RegisterType<IPlayerModelSelect, PlayerModelSelect>();
            container.RegisterType<IPlayerModelSaveLogic, PlayerModelSaveLogic>();
            container.RegisterType<IPlayerModelDeleteLogic, PlayerModelDeleteLogic>();

            //container.RegisterType<IQuarterTypeInsert, QuarterTypeInsert>();
            //container.RegisterType<IQuarterTypeSelect, QuarterTypeSelect>();
            //container.RegisterType<IQuarterTypeUpdate, QuarterTypeUpdate>();
            //container.RegisterType<IQuarterTypeDelete, QuarterTypeDelete>();

            //container.RegisterType<ITeamInsert, TeamInsert>();
            container.RegisterType<ITeamSelectLogic, TeamSelectLogic>();
            container.RegisterType<ITeamUpdateLogic, TeamUpdateLogic>();
            //container.RegisterType<ITeamDelete, TeamDelete>();
            //container.RegisterType<ITeamSelectList, TeamSelectList>();

            container.RegisterType<ITeamModelListLogic, TeamModelListLogic>();
            container.RegisterType<ITeamModelSelectLogic, TeamModelSelectLogic>();

            container.RegisterType<ITeamParseLogic, TeamParseLogic>();

            container.RegisterType<ITeamPlayersInsert, TeamPlayersInsert>();
            container.RegisterType<ITeamPlayersSelect, TeamPlayersSelect>();
            container.RegisterType<ITeamPlayersUpdate, TeamPlayersUpdate>();
            container.RegisterType<ITeamPlayersDelete, TeamPlayersDelete>();
            //container.RegisterType<ITeamPlayersParse, TeamPlayersParse>();
            container.RegisterType<ITeamPlayersSaveLogic, TeamPlayersSaveLogic>();
            container.RegisterType<ITeamPlayerSelectList, TeamPlayerSelectList>();

            container.RegisterType<ITeamPlayerModelSelectList, TeamPlayerModelSelectList>();
            container.RegisterType<ITeamPlayerModelPagedList, TeamPlayerModelPagedList>();

            //container.RegisterType<ITournamentInsert, TournamentInsert>();
            //container.RegisterType<ITournamentSelect, TournamentSelect>();
            //container.RegisterType<ITournamentUpdate, TournamentUpdate>();
            //container.RegisterType<ITournamentDelete, TournamentDelete>();

            container.RegisterType<IPeople, HtayHtay>();
            //container.RegisterType<IPeople, Garvin>();

            //container.RegisterType<IAwardUpdate, AwardUpdate>();
            //container.RegisterType<IAwardDelete, AwardDelete>();
            container.RegisterType<IAwardInsert, AwardInsert>();

            container.RegisterType<IAwardModelSelect, AwardModelSelect>();
            //container.RegisterType<IAwardModelSelectList, AwardModelSelectList>();
            container.RegisterType<IAwardModelDeleteLogic, AwardModelDeleteLogic>();
            container.RegisterType<IAwardModelUpdateLogic, AwardModelUpdateLogic>();
            container.RegisterType<IAwardModelInsertLogic, AwardModelInsertLogic>();
            container.RegisterType<IAwardModelPagedList, AwardModelPagedList>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}