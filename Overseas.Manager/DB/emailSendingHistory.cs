namespace Overseas.Manager.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("emailSendingHistory")]
    public partial class emailSendingHistory
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Client")]
        [Required(ErrorMessage = "Please select client")]
        public int? clientId { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Email Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? emailDate { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter email type")]
        [Display(Name = "Type")]
        public string emailType { get; set; }

        [Display(Name = "Is Responded>?")]
        public bool isResponded { get; set; }

        [Display(Name = "Is Unsubscribed?")]
        public bool isUnsubscribe { get; set; }

        public virtual clientMaster clientMaster { get; set; }
    }
}
