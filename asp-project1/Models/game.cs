//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asp_project1.Models
{
    using System;
    using System.Collections.Generic;

    public partial class game
    {
        public int gameID { get; set; }
        public string teamA { get; set; }
        public string teamB { get; set; }
        public int teamAScore { get; set; }
        public int teamBScore { get; set; }
        public string selectedGame { get; set; }
    }
}