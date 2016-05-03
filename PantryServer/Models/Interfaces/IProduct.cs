using System.Collections.Generic;

namespace PantryServer.Models.Interfaces
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<Tag> Tags { get; set; }
    }
}