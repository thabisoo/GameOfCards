using GameOfGards.ApplicationLogic.Entities;
using GameOfGards.ApplicationLogic.Interfaces;

namespace GameOfGards.ApplicationLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly PlayerEntity[] _players; 
        private readonly ICardService _cardService;

        public PlayerService(ICardService cardService)
        {
            _cardService = cardService;
            _players = new PlayerEntity[2];

            _players[1] = new PlayerEntity
            {
                Name = "Dealer"
            };
        }

        public int Play(int index)
        {
            var card = _cardService.PickCard(index);
            _players[index].Cards.Add(card);
            _players[index].Score += card.CardNumber.Number;
            return _players[index].Score;
        }

        public PlayerEntity GetPlayer(int index)
        {
            return _players[index];
        }

        public void InitializeHumanPlayer(string playerName) 
        {
            _players[0] = new PlayerEntity
            {
                Name = playerName
            };
        } 

        public PlayerEntity[] GetPlayers()
        {
            return _players;
        }
        public bool HasPlayerLost(int index)
        {
            return _players[index].Score > 21;
        }
    }
}
