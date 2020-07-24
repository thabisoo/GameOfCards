using GameOfCards.Domain.Models;
using GameOfGards.ApplicationLogic.Entities;
using GameOfGards.ApplicationLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfGards.ApplicationLogic.Services
{
    public class CardService : ICardService
    {
        private readonly IDeckService _deckService;
        private List<CardEntity> _cards;
        private int _playerIndex = 0;

        public CardService(IDeckService deckService)
        {
            _deckService = deckService;
            LoadShuffledCards();
        }

        public CardEntity PickCard(int index)
        {
            if(index != _playerIndex)
            {
                LoadShuffledCards();
                _playerIndex = index;
            }

            var card = InternalPickCard(_cards);
            card.IsDealt = true;
            return card;
        }

        private CardEntity InternalPickCard(List<CardEntity> cards)
        {
            var random = new Random();
            int randonIndex = random.Next(cards.Where(c => !c.IsDealt).Count());
            return cards.Where(c => !c.IsDealt).Skip(randonIndex).First();
        }

        private void LoadShuffledCards()
        {
            _cards = _deckService.LoadShuffledDeck();
        }
    }
}
