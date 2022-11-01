using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        Croupier croupier = new Croupier();
        croupier.Game();
    }

    class Croupier
    {
        private Player _player = new Player();
        private Deck _deck = new Deck();

        public void Game()
        {
            const string Exit = "exit";
            const string Show = "show";
            bool isExit = false;
            string userChoice;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("Чтобы взять карту, нажмите Enter\nЕсли вам достаточно карт, введите: " +
                    Exit + "\nЧтобы посмотреть руку, введите: " + Show);
                userChoice = Console.ReadLine();

                if (_deck.NumberCards())
                {
                    switch (userChoice)
                    {
                        default:
                            _player.TakeCard(_deck.GiveCard());
                            break;

                        case Show:
                            _player.ShowHand();
                            isExit = true;
                            break;

                        case Exit:
                            isExit = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("В колоде нет карт");
                    Console.WriteLine("Ваша рука: ");
                    _player.ShowHand();
                    isExit = true;
                }
            }
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _deck = new List<Card>();

        public Deck()
        {
            _deck = new List<Card>();
            AddCards();
        }

        private void AddCards()
        {
            string[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    _deck.Add(new Card(names[j], suits[i]));
                }
            }
        }

        public bool NumberCards()
        {
            return _deck.Count > 0;
        }

        public Card GiveCard()
        {
            Card currentCard = _deck[_random.Next(0, _deck.Count)];
            _deck.Remove(currentCard);
            return currentCard;
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
        private List<Card> _hand = new List<Card>();

        public Player()
        {
            _hand = new List<Card>();
        }

        public void TakeCard(Card currentCard)
        {
            _hand.Add(currentCard);
        }

        public void ShowHand()
        {
            foreach (Card card in _hand)
            {
                Console.WriteLine(card.Name + " " + card.Suits);                
            }
            Console.ReadKey();
        }
    }
}
