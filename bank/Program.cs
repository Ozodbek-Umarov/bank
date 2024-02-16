using bank.Interfaces;
using bank.Models;
using bank.Services;

class Program
{
    static void Main(string[] args)
    {
        IBankManager bankManager = new BankManager();

        while (true)
        {
            Console.WriteLine("WIKKO bankiga xush kelibsiz");
            Console.WriteLine("1. Registratsiya uchun");
            Console.WriteLine("2. Login uchun");
            Console.WriteLine("3. Bankimiz haqida ma'lumot");
            Console.WriteLine("4. Consolni Tozalash");
            Console.WriteLine("0. Chiqish");

            string cmd = Console.ReadLine();

            if (cmd == "1")
            {
                // 1. bankManager yordamida Register metodini chaqiring
                Console.Clear();
                bankManager.Register();
            }
            else if (cmd == "2")
            {
                User user = null;

                // 2. bankManager yordamida Login metodini chaqiring
                while (user == null)
                {
                    user = bankManager.Login();
                }

                while (true)
                {

                    Console.WriteLine("Kerakli bo'limni tanlang");
                    Console.WriteLine("1. Bank kartasi ochish");
                    Console.WriteLine("2. Kartangizni bloklash");
                    Console.WriteLine("3. Kartangizni blokdan ochish");
                    Console.WriteLine("4. Barcha kartalaringizni ko'rsatish");
                    Console.WriteLine("5. Kartadagi pul miqdori");
                    Console.WriteLine("6. Barcha pul miqdori");
                    Console.WriteLine("7. Pul kiritish");
                    Console.WriteLine("8. Pul yechish");
                    Console.WriteLine("9. Consolni tozalash");
                    Console.WriteLine("0. Chiqish");

                    string choice2 = Console.ReadLine();

                    if (choice2 == "1")
                    {   Console.Clear();
                        // 3. bankManager yordamida CreateCard metodini chaqiring
                        bankManager.CreateCard(user);
                    }
                    else if (choice2 == "2")
                    {
                        Console.Clear();
                        // 4. bankManager yordamida ShowCards metodini chaqiring
                        bankManager.ShowCards(user);
                        Console.WriteLine("Karta raqamingizni kiriting");
                        string cardNumber = Console.ReadLine();
                        // 5. bankManager yordamida BlockCard metodini chaqiring
                        bankManager.BlockCard(user, cardNumber);
                    }
                    else if (choice2 == "3")
                    {
                        Console.Clear();
                        // 6. bankManager yordamida ShowCards metodini chaqiring
                        bankManager.ShowCards(user);
                        Console.WriteLine("Karta raqamingizni kiriting");
                        string cardNumber = Console.ReadLine();
                        // 7. bankManager yordamida UnBlockCard metodini chaqiring
                        bankManager.UnBlockCard(user, cardNumber);
                    }
                    else if (choice2 == "4")
                    {

                        // 8. bankManager yordamida ShowCards metodini chaqiring
                        bankManager.ShowCards(user);
                    }
                    else if (choice2 == "5")
                    {
                        Console.Clear();
                        // 9. bankManager yordamida ShowCards metodini chaqiring
                        bankManager.ShowCards(user);
                        Console.WriteLine("Karta raqamingizni kiriting");
                        string cardNumber = Console.ReadLine();
                        // 10. bankManager yordamida ShowBalance metodini chaqiring
                        bankManager.ShowBalance(user, cardNumber);
                    }
                    else if (choice2 == "6")
                    {
                        Console.Clear() ;
                        // 11. bankManager yordamida ShowAllBalance metodini chaqiring
                        bankManager.ShowAllBalance(user);
                    }
                    else if (choice2 == "7")
                    {
                        Console.Clear();
                        // 12. bankManager yordamida ShowCards metodini chaqiring
                        bankManager.ShowCards(user);
                        Console.WriteLine("Karta raqamingizni kiriting:");
                        string cardNumber = Console.ReadLine();
                        // 13. bankManager yordamida Deposit metodini chaqiring
                        bankManager.Deposit(user, cardNumber);
                    }
                    else if (choice2 == "8")
                    {
                        Console.Clear();
                        // 14. bankManager yordamida ShowCards metodini chaqiring
                        bankManager.ShowCards(user);
                        Console.WriteLine("Karta raqamingizni kiriting");
                        string cardNumber = Console.ReadLine();
                        Console.WriteLine("Kartaning parolini kiriting");
                        string pin = Console.ReadLine();
                        // 15. bankManager yordamida Withdraw metodini chaqiring
                        bankManager.Withdraw(user, cardNumber, pin);
                    }
                    else if (choice2 == "9")
                    {
                        Console.Clear();
                    }
                    else if (choice2 == "0")
                    {
                        break;
                    }
                }
            }
            else if (cmd == "3")
            {
                Console.Clear();
                // 16. bankManager yordamida ShowBankInfo metodini chaqiring
                bankManager.ShowBankInfo();
            }
            else if (cmd == "4")
            {
                Console.Clear();
            }
            else if (cmd == "0")
            {
                break;
            }
        }
    }
}
