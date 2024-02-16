using bank.Models;

namespace bank.Interfaces
{
    public interface IAccauntManager
    {
        void Register();
        User Login();
    }
}
