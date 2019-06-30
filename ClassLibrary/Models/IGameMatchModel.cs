using System;

namespace ClassLibrary.Models
{
    public interface IGameMatchModel
    {
        int courtID { get; set; }
        string courtName { get; set; }
        DateTime datePlayed { get; set; }
        int gameID { get; set; }
        int gameTeamID1 { get; set; }
        int gameTeamID2 { get; set; }
        string matchNo { get; set; }
        string primaryUmpire { get; set; }
        int? primaryUmpireID { get; set; }
        string reserveUmpire { get; set; }
        int? reserveUmpireID { get; set; }
        string secondaryUmpire { get; set; }
        int? secondaryUmpireID { get; set; }
        int team2ID { get; set; }
        int teamID1 { get; set; }
        string teamName1 { get; set; }
        string teamName2 { get; set; }
        int teamScore1 { get; set; }
        int teamScore2 { get; set; }
        int? tournamentID { get; set; }
        string tournamentName { get; set; }
        string venue { get; set; }
    }
}