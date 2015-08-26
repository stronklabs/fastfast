using UnityEngine;
using UObject = UnityEngine.Object;
using GObject = UnityEngine.GameObject;
using URandom = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.Networking;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public abstract class Singleton : ExtBehaviour {
	public class SecondInstantiate : Exception {}

	private static Hashtable instances = new Hashtable();

	void Start () {
		if (!instances.ContainsKey (this.GetType ())) {
			instances [this.GetType ()] = this;
		} else {
			throw new SecondInstantiate ();
		}

		DontDestroyOnLoad (gameObject);
	}

	public static T GetSingleton<T> () where T: Singleton {
		return instances [typeof(T)] as T;
	}
}