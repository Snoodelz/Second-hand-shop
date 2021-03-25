using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWebShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderItems { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }
        [DisplayName("Efternamn")]
        public string LastName { get; set; }
        [DisplayName("E-post")]
        public string EmailAddress { get; set; }
        [DisplayName("Adress")]
        public string Address { get; set; }
        [DisplayName("Land")]
        public string Country { get; set; }
        public string Ort { get; set; }
        [DisplayName("Postnummer")]
        public int ZipCode { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }
}
