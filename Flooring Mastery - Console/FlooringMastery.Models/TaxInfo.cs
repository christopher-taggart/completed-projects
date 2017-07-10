using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class TaxInfo : Response
    {
        
        public string StateAbbrevation { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
