using GraphQL.Types;

namespace TestGraphQL.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "UserType";
            Field(_ => _ .Id, nullable: true);
            Field(_ => _.FirstName, nullable: true);
            Field(_ => _.LastName, nullable: true);
            Field(_ => _.CreatedAt, nullable: true);
            Field<AddressType, Address?>("Address");
        }
    }

    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Name = "AddressType";
            Field(_ => _.Street, nullable: true);
        }
    }
}
