using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseas.Manager.DbClasses
{
    [Table("clientMaster")]
    class clientRegistration
    {
        [Display(Name = "Client ID")]
        public int clientId { get; set; }

        [Display(Name = "User")]
        public int userId { get; set; }

        [Display(Name = "Domain or Branch")]
        public int domainId { get; set; }

        [Display(Name = "Confirm?")]
        public string status { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Invalid Email ID")]
        [Required(ErrorMessage = "Please enter email address", AllowEmptyStrings = false)]
        public string emailId { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please enter company name", AllowEmptyStrings = false)]
        public string companyName { get; set; }

        [Display(Name = "Contact Person Name")]
        [Required(ErrorMessage = "Please enter contact person name", AllowEmptyStrings = false)]
        public string ContactPersonName { get; set; }

        [Display(Name = "Contact Person Desgination")]
        [Required(ErrorMessage = "Please enter desgination of person", AllowEmptyStrings = false)]
        public string ContactPersonDesignation { get; set; }

        [Display(Name = "Mobile")]
        [Phone(ErrorMessage ="Invalid phone")]
        [Required(ErrorMessage = "Please enter contact person number", AllowEmptyStrings = false)]
        public decimal contactPersonContactNo1 { get; set; }

        [Display(Name = "Alternate Mobile")]
        public Nullable<decimal> contactPersonContactNo2 { get; set; }

        [Display(Name = "Telephone")]
        public Nullable<decimal> companyCellPhone { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter company address", AllowEmptyStrings = false)]
        public string address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please select city", AllowEmptyStrings = false)]
        public string city { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please select state", AllowEmptyStrings = false)]
        public string state { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please select country", AllowEmptyStrings = false)]
        public int counytryId { get; set; }

        [Display(Name ="Response")]
        public Nullable<bool> isResponded { get; set; }

        [Display(Name ="Subscribe")]
        public Nullable<bool> isUnsubscribe { get; set; }
    }
}
