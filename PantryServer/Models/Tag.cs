using PantryServer.Models.Interfaces;

namespace PantryServer.Models
{
    public class Tag : ITag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}