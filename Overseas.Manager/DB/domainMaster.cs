namespace Overseas.Manager.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("domainMaster")]
    public partial class domainMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public domainMaster()
        {
            clientMasters = new HashSet<clientMaster>();
        }

        [Key]
        [Display(Name = "Domain Id")]
        public int domainId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Domain Name")]
        public string domainName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clientMaster> clientMasters { get; set; }
    }
}
