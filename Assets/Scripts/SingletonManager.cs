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

public class SingletonManager : Singleton {
	public T Get<T> () where T: Singleton {
		return GetComponentInChildren<T> ();
	}
}
