namespace Overseas.Manager.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("userMaster")]
    public partial class userMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userMaster()
        {
            clientMasters = new HashSet<clientMaster>();
        }

        [Key]
        [Display(Name = "User")]
        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string lastName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime dob { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required]
        [Display(Name = "State")]
        public int stateId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int countryId { get; set; }

        [Required]
        [StringLength(13)]
        [MinLength(10, ErrorMessage = "Please enter only 10 digit mobile number")]
        [Display(Name = "Mobile No.")]
        public string contactNo { get; set; }

        [Required]
        [StringLength(80)]
        [RegularExpression(pattern: @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            ErrorMessage = "Please enter correct email address")]
        [Display(Name = "Email")]
        public string emailID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Password")]
        public string password { get; set; }

        public bool? rememberMe { get; set; }

        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<clientMaster> clientMasters { get; set; }

        public virtual RoleMaster RoleMaster { get; set; }

        public virtual tblCountry tblCountry { get; set; }

        public virtual tblState tblState { get; set; }
    }
}
