using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Customer
    {
        public int customerid {get; set;}

        [Required]
        [Display(Name="Customer Name:")]
        public string name {get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at {get; set;}

        public List<Order> orders {get; set;}
        public Customer()
        {
            orders = new List<Order>();
        }
    }
}