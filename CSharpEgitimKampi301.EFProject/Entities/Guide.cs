using System.Collections.Generic;

namespace CSharpEgitimKampi301.EFProject.Entities
{
    public sealed class Guide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } = default;
        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
