using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using bank.Interfaces;
using bank.Models;

namespace bank.Services
{
    public class CardManager : ICardManager
    {
        private const string CardsFilePath = "C:\\Users\\MEGA KANS\\Desktop\\bank\\bank\\database\\cards.json"; 

        public void BlockCard(User user, string cardNumber)
        {
            List<Card> cards = LoadCards();
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber)
                {
                    card.Blocked = true;
                    Console.WriteLine("kartangiz bloklandi");
                    SaveCards(cards);
                    break;
                }
            }
        }

        public Card CreateCard(User user)
        {
            Console.WriteLine("Karta raqamingiz:");
            Console.WriteLine("Agar enter bossangiz random karta taqdim etiladi");

            string cardNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(cardNumber))
            {
                Random random = new Random();
                cardNumber = string.Format("{0:D4} {1:D4} {2:D4} {3:D4}", random.Next(1000, 9999), random.Next(1000, 9999), random.Next(1000, 9999), random.Next(1000, 9999));
            }

            Console.WriteLine("Pinkodingiz");

            string pin = Console.ReadLine();
            while (!int.TryParse(pin, out _) || pin.Length != 4)
            {
                Console.WriteLine("Iltimos, to'g'ri 4 xonalik son kiriting.");
                pin = Console.ReadLine();
            }

            Card card = new Card();
            card.Number = cardNumber;
            card.PinCode = pin;

            user.Cards.Add(card);
            List<Card> cards = LoadCards();
            cards.Add(card);
            SaveCards(cards);

            Console.WriteLine("Kartangiz yarartildi va hozir u blok holatda");

            return card;
        }

        public Card GetCard(string cardNumber)
        {
            List<Card> cards = LoadCards();
            foreach (Card card in cards)
            {
                if (card.Number == cardNumber)
                {
                    return card;
                }
            }
            return new Card();
        }

        public Card GetCard(User user, string cardNumber)
        {
            List<Card> cards = LoadCards();
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber)
                {
                    return card;
                }
            }
            return new Card();
        }

        public void UnblockCard(User user, string cardNumber)
        {
            List<Card> cards = LoadCards();
            foreach (Card card in user.Cards)
            {
                if (card.Number == cardNumber)
                {
                    card.Blocked = false;
                    Console.WriteLine("karta blokdan chiqdi");
                    SaveCards(cards);
                    break;
                }
            }
        }

        private List<Card> LoadCards()
        {
            if (File.Exists(CardsFilePath))
            {
                string json = File.ReadAllText(CardsFilePath);
                return JsonSerializer.Deserialize<List<Card>>(json) ?? new List<Card>();
            }
            return new List<Card>();
        }

        private void SaveCards(List<Card> cards)
        {
            string json = JsonSerializer.Serialize(cards);
            File.WriteAllText(CardsFilePath, json);
        }
    }
}
