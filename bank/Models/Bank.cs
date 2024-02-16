namespace bank.Models
{
    public class Bank(string name, string address, string phone, List<User> users) : BaseModel
    {
        public string Name = name;
        public string Address = address;
        public string Phone = phone;
        public List<User> Users = users;

        public void GetInfo()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Address);
            Console.WriteLine(Phone);
            Console.WriteLine(Users.Count);
        }
    }
}
