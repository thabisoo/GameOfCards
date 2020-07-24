using GameOfCards.Domain.Enums;

namespace GameOfGards.ApplicationLogic.Entities
{
    public class CardEntity
    {
        public Suit Suit { get; set; }
        public CardNumberEntity CardNumber { get; set; }
        public bool IsDealt { get; set; }
    }
}
