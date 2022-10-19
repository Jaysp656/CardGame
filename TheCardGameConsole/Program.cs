using Autofac;
using TheCardGame.Console;
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

        builder.AddApplication();
        builder.AddDomain();
        builder.AddLibrary();

        return builder.Build();
    }

}