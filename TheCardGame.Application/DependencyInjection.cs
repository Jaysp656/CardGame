

using Autofac;
using TheCardGame.Application.Details;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public static class DependencyInjection {
        public static ContainerBuilder AddApplication(this ContainerBuilder builder) {
            builder.RegisterType<DeckManager>().As<IDeckManager>().SingleInstance();
            builder.RegisterType<CardGame>().As<ICardGame>();

            return builder;
        }

    }
}
