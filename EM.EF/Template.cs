namespace EM.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EM.Template")]
    public partial class Template
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string DLLName { get; set; }

        [Required]
        [StringLength(255)]
        public string FullClassName { get; set; }
    }
}
