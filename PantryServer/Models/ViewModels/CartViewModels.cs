using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PantryServer.Infrastructure;

namespace PantryServer.Models.ViewModels
{
    public class CartProductListViewModel
    {
        public List<Product> Products { get; set; }
        public string CartId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    public class CartShopListViewModel
    {
        public List<ShopInformationViewModel> Shops { get; set; }
        public List<Product> Products { get; set; }
    }
}