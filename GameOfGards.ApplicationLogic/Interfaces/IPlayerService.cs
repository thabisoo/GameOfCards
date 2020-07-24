using GameOfCards.Domain.Models;
using GameOfGards.ApplicationLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfGards.ApplicationLogic.Interfaces
{
    public interface IPlayerService
    {
        int Play(int index);

        void InitializeHumanPlayer(string playerName);

        PlayerEntity[] GetPlayers();

        PlayerEntity GetPlayer(int index);

        bool HasPlayerLost(int index);
    }
}
