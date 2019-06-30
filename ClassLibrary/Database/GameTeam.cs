
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ClassLibrary.Database
{

using System;
    using System.Collections.Generic;
    
public partial class GameTeam
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public GameTeam()
    {

        this.GamePlayers = new HashSet<GamePlayer>();

        this.GameQuarters = new HashSet<GameQuarter>();

    }


    public int GameTeamID { get; set; }

    public int GameID { get; set; }

    public int TeamID { get; set; }

    public Nullable<int> CaptainID { get; set; }

    public Nullable<int> CoachID { get; set; }

    public Nullable<int> PrimaryCarerID { get; set; }

    public Nullable<int> FinalScore { get; set; }



    public virtual Game Game { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GamePlayer> GamePlayers { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GameQuarter> GameQuarters { get; set; }

    public virtual Person Person { get; set; }

    public virtual Person Person1 { get; set; }

    public virtual Person Person2 { get; set; }

    public virtual Team Team { get; set; }

}

}
