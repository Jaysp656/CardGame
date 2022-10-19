

using Autofac;
using Autofac.Features.ResolveAnything;
using TheCardGame.Application.Details;
using TheCardGame.Application.Details.Actions;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public static class DependencyInjection {
        public static ContainerBuilder AddApplication(this ContainerBuilder builder) {
            builder.RegisterType<DeckManager>().As<IDeckManager>().SingleInstance();
            builder.RegisterType<CardGame>().As<ICardGame>();
            builder.RegisterType<GameDetailsBuilder>().AsSelf();

            //TODO:? Wire up individual Action classes?
            builder.RegisterType<DrawAction>().AsSelf();

            return builder;
        }

    }
}
