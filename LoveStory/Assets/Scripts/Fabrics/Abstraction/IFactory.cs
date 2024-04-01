using UnityEngine;

public interface IFactory
{
    void PrepareFactoryForWork(GameObject prefab, Transform parent);
    GameObject Create();
}
