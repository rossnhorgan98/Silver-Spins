using System;
using System.ComponentModel.DataAnnotations;

namespace IS4439_Assignment.Models
{
    public class Order
    {
        public Order()
        {
        }

        [Required]
        public int OrderID { get; set; }

        public Album Album { get; set; }

        public string Format { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string CardNo { get; set; }

        public int SecNo { get; set; }

        public string ExpirationDate { get; set; }

    }
}
