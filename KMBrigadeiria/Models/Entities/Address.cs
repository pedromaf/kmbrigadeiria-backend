namespace KMBrigadeiria.Models.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Complement { get; set; }
    }
}
