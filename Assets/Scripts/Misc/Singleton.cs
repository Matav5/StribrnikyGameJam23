//  <copyright file="Singleton.cs" company="Xinity">
//  Copyright (c) 2013 All Right Reserved, http://xinity.com/
// 
//  </copyright>
//  <author>Pavel Fadrhonc</author>
//  <email>pavel.fadrhonc@xinity.com</email>
//  <date>8.7.2013</date>
//  <summary>Base class for any class that wants to be a singleton. For some reason static constructor makes invoking Lazy, see http://www.yoda.arachsys.com/csharp/beforefieldinit.html</summary>
//  <quote> "When I grow up, I want to be a singleton just like my dady!" - general GameObject, Son of GameManager </quote>
//  <usage> class MySingletonClass { private MySingletonClas () {} public static MySingletonClass Instance { get { return Singleton<MySingletonClass>.Instance; } } } </usage>
using System;
using System.Reflection;

public class Singleton<T> where T : class
{
	static Singleton()
    {
    }

    public static readonly T Instance = 
        typeof(T).InvokeMember(typeof(T).Name, 
                                BindingFlags.CreateInstance | 
                                BindingFlags.Instance |
                                BindingFlags.Public |
                                BindingFlags.NonPublic, 
                                null, null, null) as T;
}

