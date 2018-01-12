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
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.ClientProperties = new HashSet<ClientProperty>();
            this.ClientStatus = new HashSet<ClientStatu>();
        }
    
        public long Id { get; set; }
        public long PluginTemplateId { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public long ClientScheduleId { get; set; }
    
        public virtual ClientSchedule ClientSchedule { get; set; }
        public virtual PluginTemplate PluginTemplate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientProperty> ClientProperties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientStatu> ClientStatus { get; set; }
    }
}
