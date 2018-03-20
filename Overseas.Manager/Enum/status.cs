using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseas.Manager.Enum
{
    public enum status
    {
        [Display(Name = "Confirmed")]
        Confirmed = 0,

        [Display(Name = "Cold")]
        Cold = 1,

        [Display(Name = "Hot")]
        Hot = 2,

        [Display(Name = "Selected Other Vendor")]
        SelectedOtherVendor = 3,

        [Display(Name = "Not To Contact")]
        NotToContact = 4,

        [Display(Name = "Very Old")]
        VeryOld = 5
    }
}
