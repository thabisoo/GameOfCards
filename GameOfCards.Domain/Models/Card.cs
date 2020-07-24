using GameOfCards.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfCards.Domain.Models
{
    public class Card
    {
        public Suit Suit { get; set; }
        public CardNumber CardNumber { get; set; }
        public bool IsDealt { get; set; }
    }
}
