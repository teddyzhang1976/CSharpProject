//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Formula1Demo
{
    using System;
    using System.Collections.Generic;
    
    public partial class RaceResult
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int Position { get; set; }
        public Nullable<int> Grid { get; set; }
        public Nullable<decimal> Points { get; set; }
        public int RacerId { get; set; }
        public int TeamId { get; set; }
    
        public virtual Race Race { get; set; }
        public virtual Racer Racer { get; set; }
        public virtual Team Team { get; set; }
    }
}
