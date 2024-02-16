using bank.Interfaces;
using bank.Models;
using System.Net.NetworkInformation;

namespace bank.Services
{
    public class BankManager : IBankManager
    {
        AccountManager accountManager = new AccountManager();
        CardManager cardManager = new CardManager();
        Bank bank = new Bank("Najot Talim", "Fergana, Uzbekistan", "+998788889888", []);
        public void BlockCard(User user, string cardNumber)
        {
            cardManager.BlockCard(user, cardNumber);
        }

        public void CreateCard(User user)
        {
            cardManager.CreateCard(user);
        }

        public void Deposit(User user, string cardNumber)
        {
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber && card.Blocked == false)
                {
                    Console.WriteLine("Pul miqdorini kiriting");
                    double sum = double.Parse(Console.ReadLine());
                    card.Balance += sum;
                    user.Balance += sum;
                }
                else
                    Console.WriteLine("xato");
            }
        }

        public User Login()
        {
            return accountManager.Login();
        }

        public void Register()
        {
            accountManager.Register();
        }

        public void ShowAllBalance(User user)
        {
            Console.WriteLine(user.Balance);
        }

        public void ShowBalance(User user, string cardNumber)
        {
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber)
                {
                    Console.WriteLine(card.Balance);
                }
                else
                    Console.WriteLine("xato");
            }
        }

        public void ShowBankInfo()
        {
            bank.GetInfo();
        }

        public void ShowCards(User user)
        {
            foreach (Card card in user.Cards)
            {
                card.GetInfo();
            }
        }

        public void UnblockCard(User user, string cardNumber)
        {
            cardManager.UnblockCard(user, cardNumber);
        }

        public void UnBlockCard(User user, string cardNumber)
        {
            cardManager.UnblockCard(user, cardNumber);
        }

        public void Withdraw(User user, string cardNumber, string pin)
        {
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber && card.PinCode == pin && card.Blocked == false)
                {
                    Console.WriteLine("Kerakli summani kiriring");
                    double pul = double.Parse(Console.ReadLine());
                    if (card.Balance >= pul)
                    {
                        card.Balance -= pul;
                        user.Balance -= pul;
                        Console.WriteLine("Pul yechish muvaffaqiyatli amalga oshirildi");
                    }
                    else
                    {
                        Console.WriteLine("Hisobingizda yetarlicha mablag' yo'q");
                    }
                }
                else
                {
                    Console.WriteLine("xato");
                }
            }
        }

    }
}
