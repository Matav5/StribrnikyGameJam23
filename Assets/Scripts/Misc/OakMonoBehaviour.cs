//  <copyright file="XinityMonoBehaviour.cs" company="Xinity">
//  Copyright (c) 2013 All Right Reserved, http://xinity.com/
// 
//  </copyright>
//  <author>Pavel Fadrhonc</author>
//  <email>pavel.fadrhonc@xinity.com</email>
//  <date>16.7.2013</date>
//  <summary>Xinity version of Monobehaviour uses a thin layer for many convenience purposes inmproving original MonoBehaviour</summary>

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public delegate void XinityTask();

public class OakMonoBehaviour : MonoBehaviour
{
    protected Transform _thisTransform;
    public Transform CachedTransform { get { return _thisTransform; } }

    protected virtual void Awake()
    {
        _thisTransform = this.transform;
    }

    /// <summary>
    /// Removes from GameObjectCache so it cannot be querried
    /// </summary>
    protected virtual void OnDestroy()
    {
        GameObjectCache.Instance.Remove(gameObject);
    }
}
