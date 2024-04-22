namespace WarehouseDataLayer
{
    public class Person(string FirstName, string LastName, int Id)
    {
        public string FirstName { get; set; } = FirstName;
        public string LastName { get; set; } = LastName;
        public int Id { get; set; } = Id;

        public override string ToString()
        {
            return $"{FirstName} {LastName} (ID: {Id})";
        }
    }
}
