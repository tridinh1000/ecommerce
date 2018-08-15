using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Order
    {
        public int orderid {get; set;}

        public int quantity {get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }

        public int customerid {get; set;}
        public Customer customer {get; set;}

        public int productid {get; set;}
        public Product product {get; set;}
    }
}