using UnityEngine;
using Zenject;

public class MainSceneContext : MonoInstaller
{
    [SerializeField] private MainSceneObjects _mainSceneObjects;
    public override void InstallBindings()
    {
        BindMainSceneObjects();

    }

    private void BindMainSceneObjects()
    {
        Container.
            Bind<MainSceneObjects>()
            .FromInstance(_mainSceneObjects)
            .AsSingle();
    }
}
