using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PantryServer.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public List<ApplicationUser> Administrator { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public int PhoneNumber { get; set; }
    }
}