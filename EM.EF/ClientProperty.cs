namespace EM.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EM.ClientProperty")]
    public partial class ClientProperty
    {
        public long Id { get; set; }

        public long ClientID { get; set; }

        [Required]
        [StringLength(255)]
        public string Key { get; set; }

        public string Value { get; set; }

        public virtual Client Client { get; set; }
    }
}
