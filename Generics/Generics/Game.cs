using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Game
    {
        List<Card> deckOfCard;
        List<Player> players;
        int countOfCards = 36;

        public void CreateDeck()
        {
            deckOfCard = new List<Card>();
            for (int i = 0; i < Enum.GetValues(typeof(Suits)).Length; i++)
            {
                for (int j = 0; j < Enum.GetValues(typeof(Values)).Length; j++)
                {
                    deckOfCard.Add(new Card((Suits)Enum.GetValues(typeof(Suits)).GetValue(i),
                        (Values)Enum.GetValues(typeof(Values)).GetValue(j)));
                }
            }
            List<Card> mixedCards = new List<Card>();
            Random random = new Random();
            int index;
            int count = countOfCards;
            while (mixedCards.Count < countOfCards)
            {
                index = random.Next(count);
                mixedCards.Add(deckOfCard[index]);
                deckOfCard.Remove(deckOfCard[index]);
                count--;
            }
            deckOfCard = mixedCards;
        }

        public void AddPlayers(int countOfPlayers)
        {
            if (countOfPlayers > 6 || countOfPlayers < 2 || countOfPlayers == 5)
            {
                throw new ArgumentOutOfRangeException("Задано неправильное количество игроков");
            }
            players = new List<Player>(countOfPlayers);
            for (int i = 0; i < countOfPlayers; i++)
            {
                players.Add(new Player(i + 1));
            }
        }

        public void HandingOutCards()
        {
            while (deckOfCard.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    players[i].Cards.Add(deckOfCard[0]);
                    deckOfCard.Remove(deckOfCard[0]);
                }
            }
        }
        public void ShowCards()
        {
            foreach (var player in players)
            {
                foreach (var card in player.Cards)
                {
                    Console.WriteLine($"Игрок с номером {player.Number} имеет на руках {card.CardSuit} {card.CardValue}");
                }
            }
        }
        public void PlayGame()
        {
            while (true)
            {
                int max = 0;
                List<Card> tableWithCards = new List<Card>();
                foreach (var player in players)
                {
                    Console.WriteLine($"Игрок {player.Number} положил {player.Cards.First().CardSuit} {player.Cards.First().CardValue}");
                    tableWithCards.Add(player.Cards.First());
                    player.Cards.Remove(player.Cards.First());
                }
                for (int i = 1; i < tableWithCards.Count; i++)
                {
                    if (tableWithCards[max].CardValue < tableWithCards[i].CardValue)
                    {
                        max = i;
                    }
                }
                Console.WriteLine($"Карты забирает игрок {players[max].Number}");
                foreach (var card in tableWithCards)
                {
                    players[max].Cards.Add(card);
                }
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].Cards.Count == 0)
                    {
                        Console.WriteLine($"Игрок {players[i].Number} выбывает из игры");
                        players.Remove(players[i]);
                        i = 0;
                    }
                }
                if (players.Count == 1)
                {
                    Console.WriteLine($"Победил игрок под номером {players.First().Number}");
                    break;
                }
            }
        }

    }
}
