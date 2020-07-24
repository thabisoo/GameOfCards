using GameOfCards.Domain.Enums;
using GameOfCards.Domain.Models;
using GameOfGards.ApplicationLogic.Entities;
using GameOfGards.ApplicationLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfGards.ApplicationLogic.Services
{
    public class DeckService : IDeckService
    {

        public List<CardEntity> LoadShuffledDeck()
        {
            var cards = LoadDeck();
            return cards.Select(c => new CardEntity
            {
                CardNumber = new CardNumberEntity
                {
                    Name = c.CardNumber.Name,
                    Number = c.CardNumber.Number
                },
                IsDealt = c.IsDealt,
                Suit = c.Suit
            })
            .OrderBy(c => Guid.NewGuid())
            .ToList();
        }

        private List<Card> LoadDeck()
        {
            return Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable
                .Range(1, 13)
                .Select(c => new Card
                {
                    Suit = (Suit)s,
                    CardNumber = new CardNumber
                    {
                        Name = Enum.GetName(typeof(CardValue), c),
                        Number = c < 10 ? c : 10
                    }
                }))
                .ToList();
        }
    }
}
