using GameOfCards.Common.DotNetCoreDI;
using GameOfCards.ConsoleApp.Constants;
using GameOfGards.ApplicationLogic.Entities;
using GameOfGards.ApplicationLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GameOfCards.ConsoleApp
{
    class Program
    {
        private static readonly IServiceProvider _container = new ContainerBuilder().Build();
        private static readonly IPlayerService _playerService = _container.GetService<IPlayerService>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hi Please enter you name.");
            var playerName = Console.ReadLine();
            Console.WriteLine($"Hi {playerName}. Your first card has been dealt.");

            _playerService.InitializeHumanPlayer(playerName);

            var hasHumanPlayerLost = HumansTurnCheckIfLost();
            if (!hasHumanPlayerLost)
            {
                DisplayGameInfo();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("You Lose");
                DisplayPlayerInfo(_playerService.GetPlayer(0));
            }
            Console.ReadLine();
        }

        static bool HumansTurnCheckIfLost()
        {
            do
            {
                _playerService.Play(Players.HUMAN);
                if (_playerService.HasPlayerLost(Players.HUMAN))
                {
                    return true;
                }

                Console.WriteLine($"Enter y to contine or any key to end your turn.");
            }
            while (Console.ReadLine().Contains("y"));

            return false;
        }

        static bool DealersTurnCheckIfLost()
        {
            var score = 0;
            do
            {
                score = _playerService.Play(Players.DEALER);
                if (_playerService.HasPlayerLost(Players.DEALER))
                {
                    return true;
                }
            }
            while (score <= 17);
            return false;
        }

        static void DisplayPlayerInfo(PlayerEntity player)
        {
            Console.WriteLine($"Player: {player.Name}");
            Console.WriteLine($"Cards");
            foreach (var card in player.Cards)
            {
                Console.WriteLine($"{card.CardNumber.Name} of {card.Suit}");
            }
            Console.WriteLine($"Score {player.Score}");
            Console.WriteLine("");
        }

        static void DisplayGameInfo()
        {
            var hasDealerLost = DealersTurnCheckIfLost();
            var human = _playerService.GetPlayer(Players.HUMAN);
            var dealer = _playerService.GetPlayer(Players.DEALER);

            var gameState = hasDealerLost || dealer.Score < human.Score 
                ? "You win" : "You Lose";

            Console.WriteLine(gameState);

            DisplayPlayerInfo(human);
            Console.WriteLine("");
            DisplayPlayerInfo(dealer);
        }
    }
}
