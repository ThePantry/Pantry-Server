using PantryServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PantryServer.Models
{
    public class PantryOrder
    {
        public int Id { get; set; }
        public List<ShopOrder> shopOrders { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreated { get; set; }
        public string DeliveryAddress { get; set; }
        public ApplicationUser User { get; set; }
        public Cart Cart { get; set; }
    }
}