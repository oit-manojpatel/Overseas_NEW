namespace Overseas.Manager.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblState
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblState()
        {
            clientMasters = new HashSet<clientMaster>();
            userMasters = new HashSet<userMaster>();
        }

        [Key]
        [Display(Name = "State Id")]
        public int stateId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "State Name")]
        public string stateName { get; set; }

        [Display(Name = "Country")]
        public int countryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clientMaster> clientMasters { get; set; }

        public virtual tblCountry tblCountry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userMaster> userMasters { get; set; }
    }
}
