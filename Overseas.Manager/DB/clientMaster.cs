namespace Overseas.Manager.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("clientMaster")]
    public partial class clientMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientMaster()
        {
            emailSendingHistories = new HashSet<emailSendingHistory>();
        }

        [Key]
        [Display(Name = "Client ID")]
        public int clientId { get; set; }

        [Display(Name = "User")]
        [Required]
        public int userId { get; set; }

        [Required]
        [Display(Name = "Domain")]
        public int domainId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Status")]
        public string status { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Email")]
        public string emailId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Company Name")]
        public string companyName { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Person Name")]
        public string ContactPersonName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Desgination")]
        public string ContactPersonDesignation { get; set; }

        [Required]
        [StringLength(13)]
        [Display(Name = "Mobile No")]
        public string contactPersonContactNo1 { get; set; }

        [StringLength(13)]
        [Display(Name = "Alternet No.")]
        public string contactPersonContactNo2 { get; set; }

        [StringLength(13)]
        [Display(Name = "Telephone")]
        public string companyCellPhone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public int stateId { get; set; }

        [Display(Name = "Country")]
        public int countryId { get; set; }

        [Display(Name = "Is Responded?")]
        public bool isResponded { get; set; }

        [Display(Name = "Is Unsubscribed?")]
        public bool isUnsubscribe { get; set; }

        public DateTime? createdDate { get; set; }

        [StringLength(50)]
        public string createdBy { get; set; }

        [Display(Name = "Technology")]
        public string technology { get; set; }

        [Display(Name = "Comment")]
        public string comment { get; set; }

        public virtual domainMaster domainMaster { get; set; }

        public virtual tblCountry tblCountry { get; set; }

        public virtual tblState tblState { get; set; }

        public virtual userMaster userMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emailSendingHistory> emailSendingHistories { get; set; }
    }
}
