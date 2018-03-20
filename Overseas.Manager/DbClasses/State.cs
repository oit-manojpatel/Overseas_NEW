using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseas.Manager.DbClasses
{
    class State
    {

        public int stateId { get; set; }

        public string stateName { get; set; }

        [ForeignKey("Country")]
        public int countryId { get; set; }

      //      public virtual ICollection<city> Citys { get; set; }
    }
}
