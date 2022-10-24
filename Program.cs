using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        Deck deck = new Deck();
        Player player = new Player();

        deck.AddCard();

        deck.IssueCard(player.Attemps);

        deck.ShowHand();
    }

    class Deck
    {
        Random random = new Random();
        private List<Card> _deck = new List<Card>();
        private List<Card> _hand = new List<Card>();

        public Deck()
        {
            _deck = new List<Card>();
        }

        public void AddCard()
        {
            _deck.Add(new Card("2", "Hearts"));
            _deck.Add(new Card("3", "Hearts"));
            _deck.Add(new Card("4", "Hearts"));
            _deck.Add(new Card("5", "Hearts"));
            _deck.Add(new Card("6", "Hearts"));
            _deck.Add(new Card("7", "Hearts"));
            _deck.Add(new Card("8", "Hearts"));
            _deck.Add(new Card("9", "Hearts"));
            _deck.Add(new Card("10", "Hearts"));
            _deck.Add(new Card("Jack", "Hearts"));
            _deck.Add(new Card("Queen", "Hearts"));
            _deck.Add(new Card("King", "Hearts"));
            _deck.Add(new Card("Ace", "Hearts"));
            _deck.Add(new Card("2", "Diamonds"));
            _deck.Add(new Card("3", "Diamonds"));
            _deck.Add(new Card("4", "Diamonds"));
            _deck.Add(new Card("5", "Diamonds"));
            _deck.Add(new Card("6", "Diamonds"));
            _deck.Add(new Card("7", "Diamonds"));
            _deck.Add(new Card("8", "Diamonds"));
            _deck.Add(new Card("9", "Diamonds"));
            _deck.Add(new Card("10", "Diamonds"));
            _deck.Add(new Card("Jack", "Diamonds"));
            _deck.Add(new Card("Queen", "Diamonds"));
            _deck.Add(new Card("King", "Diamonds"));
            _deck.Add(new Card("Ace", "Diamonds"));
            _deck.Add(new Card("2", "Spades"));
            _deck.Add(new Card("3", "Spades"));
            _deck.Add(new Card("4", "Spades"));
            _deck.Add(new Card("5", "Spades"));
            _deck.Add(new Card("6", "Spades"));
            _deck.Add(new Card("7", "Spades"));
            _deck.Add(new Card("8", "Spades"));
            _deck.Add(new Card("9", "Spades"));
            _deck.Add(new Card("10", "Spades"));
            _deck.Add(new Card("Jack", "Spades"));
            _deck.Add(new Card("Queen", "Spades"));
            _deck.Add(new Card("King", "Spades"));
            _deck.Add(new Card("Ace", "Spades"));
            _deck.Add(new Card("2", "Clubs"));
            _deck.Add(new Card("3", "Clubs"));
            _deck.Add(new Card("4", "Clubs"));
            _deck.Add(new Card("5", "Clubs"));
            _deck.Add(new Card("6", "Clubs"));
            _deck.Add(new Card("7", "Clubs"));
            _deck.Add(new Card("8", "Clubs"));
            _deck.Add(new Card("9", "Clubs"));
            _deck.Add(new Card("10", "Clubs"));
            _deck.Add(new Card("Jack", "Clubs"));
            _deck.Add(new Card("Queen", "Clubs"));
            _deck.Add(new Card("King", "Clubs"));
            _deck.Add(new Card("Ace", "Clubs"));
        }

        public void ShowHand()
        {
            foreach (Card card in _hand)
            {
                Console.WriteLine(card.Name + " " + card.Suits);
            }
        }

        public void IssueCard(int attemps)
        {
            const string Exit = "exit";
            bool exit = false;
            string userChoice;

            while (exit == false)
            {
                Console.WriteLine("Чтобы взять карту, нажмите Enter\nЕсли вам достаточно карт, введите: " + Exit + "\nосталось попыток: " + attemps);
                userChoice = Console.ReadLine();

                if (attemps-- > 0)
                {
                    switch (userChoice)
                    {
                        default:
                            TakeCards();
                            break;

                        case Exit:
                            exit = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("У вас закончились попытки");
                    exit = true;
                }
            }
        }

        public void TakeCards()
        {
            bool isTake = false;
            int firstIndexCard = 0;
            int lastIndexCard = 52;

            while (isTake == false)
            {
                Card currentCard = _deck[random.Next(firstIndexCard, lastIndexCard)];

                if (IsRepeat(currentCard) == false)
                {
                    AddCard(currentCard);
                    isTake = true;
                }
            }
        }

        public bool IsRepeat(Card currentCard)
        {
            return _hand.Contains(currentCard);
        }

        public void AddCard(Card currentCard)
        {
            _hand.Add(currentCard);
        }
    }

    class Card
    {
        public string Name { get; private set; }
        public string Suits { get; private set; }

        public Card(string name, string suits)
        {
            Name = name;
            Suits = suits;
        }
    }

    class Player
    {
        public int Attemps { get; private set; }

        public Player()
        {
            Attemps = 5;
        }
    }
}