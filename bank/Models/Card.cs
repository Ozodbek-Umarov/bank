namespace bank.Models
{
    public class Card : BaseModel
    {
        public string Number { get; set; }
        public string PinCode { get; set; }
        public double Balance { get; set; }
        public DateTime ExpireAT { get; set; }
        public bool Blocked { get; set; }

        public void GetInfo()
        {
            Console.WriteLine(Number);
            Console.WriteLine(Balance);
        }
    }
}
