﻿using Autofac;
using TheCardGame.Console;
using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

internal class Program
{
    private static void Main(string[] args)
    {
        CompositionRoot().Resolve<TheCardGameApp>().Run();
    }

    public static IContainer CompositionRoot()
    {      
        var builder = new ContainerBuilder();
        builder.RegisterType<TheCardGameApp>().As<TheCardGameApp>();
        builder.RegisterType<CardGameBuilder>().As<ICardGameBuilder>().SingleInstance();
        builder.RegisterType<DeckManager>().As<IDeckManager>().SingleInstance();
        builder.RegisterType<CardGame>().As<ICardGame>();
        builder.RegisterType<Players>().As<IPlayers>();
        builder.RegisterType<Deck>().As<IDeck>();

        //builder.RegisterType<Player>().As<IPlayer>();

        return builder.Build();

    }

}