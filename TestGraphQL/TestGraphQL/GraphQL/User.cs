namespace TestGraphQL.GraphQL
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Other { get; set; }
        public Address Address { get; set; }

    }
    public class Address 
    {
        public string Street { get; set; }
    }
}
