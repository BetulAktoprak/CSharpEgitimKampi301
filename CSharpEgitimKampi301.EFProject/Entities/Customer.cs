namespace CSharpEgitimKampi301.EFProject.Entities
{
    public sealed class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } = default;
        public decimal Balance { get; set; }
    }
}
