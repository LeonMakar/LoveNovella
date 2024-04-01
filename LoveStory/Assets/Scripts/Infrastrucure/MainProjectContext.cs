using Zenject;

public class MainProjectContext : MonoInstaller
{
    public override void InstallBindings()
    {
        BindStaticImageFactory();
    }

    private void BindStaticImageFactory()
    {
        Container
            .Bind<StaticImageFactory>()
            .FromNew()
            .AsSingle()
            .NonLazy();
    }
}
