namespace WarehouseDataLayer
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (ID: {Id})";
        }

    }
}
