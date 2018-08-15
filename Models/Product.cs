using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        public int productid {get; set;}

        [Required]
        [Display(Name="Name:")]
        public string name {get;set;}

        [Display(Name="Image(url):")]
        public string url {get;set;}
        
        [Display(Name="Description:")]
        public string description {get;set;}

        [Display(Name="Initial Quantity:")]
        public int quantity {get;set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at {get; set;}

        public List<Order> orders {get; set;}
        public Product()
        {
            orders = new List<Order>();
        }
    }
}