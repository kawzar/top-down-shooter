using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Pool<T> where T : MonoBehaviour
{
    private readonly T prefab;

    public List<T> pooledObjects { get; protected set; } = new List<T>();

    public Pool(T prefab)
    {
        this.prefab = prefab;
    }

    [HideInInspector]
    public Func<MonoBehaviour, bool> canBeUsedCondition = ((x) =>
    {
        return !x.gameObject.activeInHierarchy;
    });

    [HideInInspector]
    public Action<T> OnCreated;

    public T Get()
    {
        foreach (T o in pooledObjects)
        {
            if (canBeUsedCondition(o))
            {
                return o;
            }
        }

        return CreateNew();
    }

    private T CreateNew()
    {
        T newObject = MonoBehaviour.Instantiate(prefab);
        pooledObjects.Add(newObject);
        OnCreated?.Invoke(newObject);
        return newObject;
    }
}
