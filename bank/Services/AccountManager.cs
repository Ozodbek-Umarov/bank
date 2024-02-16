using bank.Interfaces;
using bank.Models;
using System.Text.Json;

namespace bank.Services
{
    public class AccountManager : IAccauntManager
    {
        private List<User> Users = new List<User>();
        User newUser1 = new User
        {
            Password = "77777777",
            Phone = "+998943814151",
            FullName = "Ozodbek Umarov"
        };
        public User Login()
        {
            User ans = new User();
            Console.Clear();
            Console.WriteLine("Telefon Raqamingiz");
            string Number = Console.ReadLine();
            Console.WriteLine("Parolingiz");
            string Password = Console.ReadLine();
            Console.WriteLine("login qildingiz");
            foreach (User user in Users)
            {
                if (user.Password == Password && user.Phone == Number)
                {
                    return user;
                }
            }
            return ans;
        }

        public void Register()
        {
            Console.WriteLine("Ismingiz va familyangiz:");
            string fullName = Console.ReadLine();

            while (fullName.Split(' ').Length != 2 && fullName.Split(' ').Length != 3)
            {
                Console.WriteLine("Iltimos, ism va familyani to'liq kiriting:");
                fullName = Console.ReadLine();
            }

            Console.WriteLine("Telefon raqamingiz:");
            string phone = Console.ReadLine();

            while (IsPhoneNumberRegistered(phone) || !phone.StartsWith("+998") || phone == "+998943814151" || phone.Length == 12 || !phone.Substring(1).All(char.IsDigit))
            {
                if (phone == "+998943814151")
                {
                    Console.WriteLine("Bu raqam Wikko uchun tegishli!");
                }
                Console.WriteLine("Iltimos, telefon raqamingizni to'g'ri kiriting (+998943814151) yoki bu nomer oldin registratsiya qilingan bo'lishligi mumkin:");
                phone = Console.ReadLine();
            }

            Console.WriteLine("Parolingiz:");
            string password = Console.ReadLine();

            while (password.Length < 8)
            {
                Console.WriteLine("Iltimos, parolingiz kamida 8 belgidan iborat bo'lsin:");
                password = Console.ReadLine();
            }

            User user = new User
            {
                Password = password,
                Phone = phone,
                FullName = fullName
            };

            // Save user data to a JSON file
            SaveUsersToJson(GetUsers());

            Console.Clear();
            Console.WriteLine("Siz muvaffaqiyatli registratsiyadan o'tdingiz, kerakli buyruqni kiriting.");
        }

        public static List<User> GetUsers()
        {
            return Users;
        }

        public static void SaveUsersToJson(List<User> users)
        {
            string filePath = "C:\\Users\\MEGA KANS\\Desktop\\bank\\bank\\database\\users.json";

            string jsonData = JsonSerializer.Serialize(value: users, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, jsonData);

            Console.WriteLine("User data has been successfully saved to users.json.");
        }


        private bool IsPhoneNumberRegistered(string phoneNumber)
        {
            return Users.Any(user => user.Phone == phoneNumber);
        }


    }
}
