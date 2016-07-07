using PantryServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;


namespace PantryServer.Models
{
    public class Cart
    {
        [Key, ForeignKey("PantryOrder")]
        public int Id { get; set;}
        // Our Cart items will have a string identifier named CartID to allow anonymous shopping. this will be used with cookies?
        public string CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Product> Products { get; set; }
        public PantryOrder PantryOrder{ get; set; }
        public string Instructions { get; set; }
        public int NumberOfItems { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public bool Abandoned { get; set; }
    }
}