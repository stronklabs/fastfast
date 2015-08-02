using UnityEngine;
using UObject = UnityEngine.Object;
using GObject = UnityEngine.GameObject;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Networking;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public struct Damage {
    public enum Type {
        physical,
        frost,
        fire
    };

    public float count;
    public Type type;
}
