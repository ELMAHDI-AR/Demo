//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoCalendar
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartAt { get; set; }
        public Nullable<System.DateTime> EndAt { get; set; }
        public Nullable<bool> IsFullDay { get; set; }
    }
}
