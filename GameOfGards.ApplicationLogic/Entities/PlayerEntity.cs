using System.Collections.Generic;

namespace GameOfGards.ApplicationLogic.Entities
{
    public class PlayerEntity
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public List<CardEntity> Cards { get; set; } = new List<CardEntity>();
    }
}
