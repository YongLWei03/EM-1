//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EM.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientStatu
    {
        public int Id { get; set; }
        public System.DateTime DateTime { get; set; }
        public long ClientId { get; set; }
        public System.DateTime LastRun { get; set; }
        public System.DateTime LastLifeSign { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
