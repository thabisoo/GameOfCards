using GameOfCards.Domain.Models;
using GameOfGards.ApplicationLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfGards.ApplicationLogic.Interfaces
{
    public interface ICardService
    {
        CardEntity PickCard(int index);
    }
}
