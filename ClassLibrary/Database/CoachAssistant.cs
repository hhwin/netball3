
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
    
public partial class CoachAssistant
{

    public int AssistantCoachID { get; set; }

    public int TeamID { get; set; }

    public int PersonID { get; set; }

    public bool ActiveInd { get; set; }

    public Nullable<System.DateTime> StartDate { get; set; }

    public Nullable<System.DateTime> EndDate { get; set; }

    public string Comments { get; set; }



    public virtual Person Person { get; set; }

    public virtual Team Team { get; set; }

}

}