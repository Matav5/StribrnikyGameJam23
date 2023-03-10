//  <copyright file="SceneSingleton.cs" company="Xinity">
//  Copyright (c) 2013 All Right Reserved, http://xinity.com/
// 
//  </copyright>
//  <author>Pavel Fadrhonc</author>
//  <email>pavel.fadrhonc@xinity.com</email>
//  <date>8.7.2013</date>
//  <summary>Base class for any singleton that want to be physically present in scene (i.e. for easier debugging and tweaking) 
// 		 it has drawback of being MonoBehaviour which brings a lot of overhead. Does not persist through scene load. Use
//      GameSingleton for that purpose. </summary>

using System;
using UnityEngine;

public class SceneSingleton<T> : OakMonoBehaviour where T : OakMonoBehaviour
{
    protected static T _instance;

    protected SceneSingleton() { }

    private static object _lock = new object();

    //private static bool _applicationIsQuitting = false;

    //   Returns the instance of this singleton.
    public static T Instance
    {
        get
        {
            //          if (_applicationIsQuitting)
            //          {
            //              return null;
            //          }

            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        var go = new GameObject(typeof(T).Name);
                        _instance = go.AddComponent<T>();
                        Debug.Log(typeof(T).Name + " singleton got created", go);
                    }
                }

                return _instance;
            }
        }
    }
    protected override void Awake()
    {
        base.Awake();
        if (_instance == null)
            _instance = this as T;
    }
    // public static Y GetInstance<Y>() where Y : OakMonoBehaviour { return _instance as Y; }
    public new void OnDestroy()
    {
        //_applicationIsQuitting = true;
    }
    public static bool HasInstance()
    {
        return _instance != null;
    }
}

