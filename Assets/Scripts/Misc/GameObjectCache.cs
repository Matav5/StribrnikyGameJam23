using UnityEngine;
using System;
using System.Collections.Generic;

public class GameObjectCache
{
	protected GameObjectCache() {}
	
	public static GameObjectCache Instance { get { return Singleton<GameObjectCache>.Instance; } }
	
	public delegate void Initialize(GameObject obj);
	public delegate GameObject Create();
	
	private Dictionary<string, List<GameObject>> _gameObjects = new Dictionary<string, List<GameObject>>();
	
	public GameObject Get(string key, Initialize init = null, Create create = null)
	{
 		foreach (var pair in _gameObjects)
		{
			if (pair.Key == key)
			{
				foreach(var go in pair.Value)
				{
				    try
				    {
                        if (!go.activeSelf)
                        {
                            go.SetActive(true);
                            if (init != null)
                                init(go);
                            return go;
                        }
                    }
				    catch (Exception)
				    {
				        return CreateNewObject(key, init, create);
				    }	
				}
			}
		}
		
		// it's not there...
		
		return CreateNewObject(key, init, create);
	}

    private GameObject CreateNewObject(string key, Initialize init = null, Create create = null)
    {
        GameObject newObj;
		if (create != null)
			newObj = create();
		else
			newObj = new GameObject();
			
		if (init != null)	
			init(newObj);
			
		if (!_gameObjects.ContainsKey(key))
		{
			List<GameObject> gameObjects = new List<GameObject>();
			gameObjects.Add(newObj);
			_gameObjects.Add(key, gameObjects);
		}
		else
		{
			_gameObjects[key].Add(newObj);
		}

        return newObj;
    }

    /// <summary>
    /// Return gameobject so it can reused
    /// </summary>
	public void Return(GameObject obj)
	{
		obj.SetActive(false);
	}

    /// <summary>
    /// Remove gameobject so it cannot be querried
    /// </summary>
    public void Remove(GameObject obj)
    {
        if (_gameObjects.ContainsKey(obj.name))
        {
            _gameObjects[obj.name].Remove(obj);
        }
    }

    /// <summary>
    /// Clears whole cache - usefull for scene transitioning
    /// </summary>
    public void Clear()
    {
        _gameObjects.Clear();
    }
}
