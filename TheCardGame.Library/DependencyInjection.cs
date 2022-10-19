

using Autofac;
using TheCardGame.Application.Details;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public static class DependencyInjection {
        public static ContainerBuilder AddLibrary(this ContainerBuilder builder) {
            builder.RegisterType<CardGameBuilder>().As<ICardGameBuilder>().SingleInstance();
            builder.RegisterType<GameActions>().As<IGameActions>();
            builder.RegisterType<PlayerBuilder>().As<PlayerBuilder>();
            builder.RegisterType<Players>().As<IPlayers>();
            builder.RegisterType<GamePhase>().As<IGamePhase>();

            return builder;
        }

    }
}
