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
        Player player = new Player();
        Deck deck = new Deck();

        public void Game()
        {
            const string Exit = "exit";
            const string Show = "show";
            bool isExit = false;
            string userChoice;
            byte numberCards = 52;

            while (isExit == false)
            {
                Console.Clear();
                Console.WriteLine("Чтобы взять карту, нажмите Enter\nЕсли вам достаточно карт, введите: " +
                    Exit + "\nЧтобы посмотреть руку, введите: " + Show + "\nВ колоде осталось: " +
                    numberCards + " карт");
                userChoice = Console.ReadLine();

                if (numberCards-- > 0)
                {
                    switch (userChoice)
                    {
                        default:
                            player.TakeCards(deck.IssueCard());
                            break;

                        case Show:
                            player.ShowHand();
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
                    player.ShowHand();
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
            string[] name = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < name.Length; j++)
                {
                    _deck.Add(new Card(name[j], suits[i]));
                }
            }
        }

        public Card IssueCard()
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

        public void TakeCards(Card currentCard)
        {
            _hand.Add(currentCard);
        }

        public void ShowHand()
        {
            foreach (Card card in _hand)
            {
                Console.WriteLine(card.Name + " " + card.Suits);
            }
        }
    }
}
