using bank.Models;

namespace bank.Interfaces
{
    public interface IBankManager
    {
        void Register();
        User Login();
        void CreateCard(User user);
        void BlockCard(User user, string cardNumber);
        void UnblockCard(User user, string cardNumber);
        void ShowCards(User user);
        void ShowBalance(User user, string cardNumber);
        void ShowAllBalance(User user);
        void ShowBankInfo();
        void Deposit(User user, string cardNumber);
        void Withdraw(User user, string cardNumber, string pin);
        void UnBlockCard(User user, string cardNumber);
    }
}
