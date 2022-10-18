
using Autofac;
using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public static class DependencyInjection {
        public static ContainerBuilder AddDomain(this ContainerBuilder builder) {
            builder.RegisterType<Hand>().As<IHand>();
            builder.RegisterType<Deck>().As<IDeck>();
            builder.RegisterType<Player>().As<IPlayer>();
            builder.RegisterType<Deck>().As<IDeck>();

            return builder;
        }

    }
}
