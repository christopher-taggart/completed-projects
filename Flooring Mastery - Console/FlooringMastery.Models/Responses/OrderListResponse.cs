using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class OrderListResponse : Response
    {
        public List<Order> Orders { get; set; }

        public OrderListResponse()
        {
           this.Orders = new List<Order>();
        }
    }
}
    