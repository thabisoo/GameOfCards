using GameOfGards.ApplicationLogic.Interfaces;
using GameOfGards.ApplicationLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GameOfCards.Common.DotNetCoreDI
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container.AddSingleton<IDeckService, DeckService>();
            container.AddSingleton<ICardService, CardService>();
            container.AddSingleton<IPlayerService, PlayerService>();

            return container.BuildServiceProvider();
        }
    }
}
