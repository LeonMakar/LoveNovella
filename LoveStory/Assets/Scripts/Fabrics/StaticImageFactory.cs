using TMPro.EditorUtilities;
using UnityEngine;
using Zenject;

public class StaticImageFactory : IFactory
{
    private GameObject _prefab;
    private Transform _parent;
    private DiContainer _container;

    public StaticImageFactory(DiContainer diContainer)
    {
        _container = diContainer;
    }
    public GameObject Create()
    {
        GameObject clone = GameObject.Instantiate(_prefab, _parent);
        foreach (var item in clone.GetComponent<ChoiseDetectorHolder>().ChoiseDetectors)
        {
            item.Init(_container.Resolve<MainSceneObjects>());
        } 
        return clone;
    }

    public void PrepareFactoryForWork(GameObject prefab, Transform parent)
    {
        _parent = parent;
        _prefab = prefab;
    }


}
